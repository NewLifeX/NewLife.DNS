using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLife.Agent;
using NewLife.Configuration;
using NewLife.DNS.Entity;
using NewLife.Log;
using NewLife.Net.DNS;

namespace NewLife.DNS.Server
{
    public class AgentService : AgentServiceBase<AgentService>
    {
        #region 属性
        public override int ThreadCount { get { return 1; } }

        public override string Description { get { return "DNS服务器"; } }
        #endregion

        #region 构造函数
        public AgentService()
        {
            ServiceName = "NewLife.DNS";
        }
        #endregion

        #region 核心
        public override bool Work(int index) { return false; }

        DNSServer Server;

        public override void StartWork()
        {
            // 修改数据库默认目录
            var xcode = XCode.Setting.Current;
            if (xcode.IsNew)
            {
                xcode.ShowSQL = false;
                xcode.SQLiteDbPath = "..\\Data";
                xcode.Save();
            }

            // 初始化数据库
            Task.Run(() =>
            {
                var n = 0;
                n = Rule.Meta.Count;
                n = Record.Meta.Count;
                n = Visitor.Meta.Count;
            });

            var set = Setting.Current;

            // 启动服务器
            var svr = new DNSServer();
            svr.Parent = set.DNSServer + "," + svr.Parent;
            svr.OnRequest += Server_OnRequest;
            svr.OnResponse += Server_OnResponse;
            svr.OnNew += Server_OnNew;

            if (set.Debug) svr.Log = XTrace.Log;
            svr.Start();

            Server = svr;

            base.StartWork();
        }

        public override void StopWork()
        {
            base.StopWork();

            var svr = Server;
            svr.Stop();
            svr.OnRequest -= Server_OnRequest;
            svr.OnResponse -= Server_OnResponse;
            svr.OnNew -= Server_OnNew;
        }
        #endregion

        #region 业务
        void Server_OnRequest(object sender, DNSEventArgs e)
        {
            var dns = e.Request;
            if (dns == null) return;

            // 查询规则
            var rs = CheckRule(dns);

            // 查询记录
            if (rs == null) rs = CheckRecord(dns);

            if (rs != null) e.Response = rs;
        }

        DNSEntity CheckRule(DNSEntity dns)
        {
            var rq = dns.Questions[0];
            var list = Rule.FindAllByQueryTypeAndName((Int32)rq.Type, rq.Name);
            if (list == null || list.Count == 0) return null;

            var rs = new DNSEntity();
            rs.Questions = dns.Questions;
            var drs = new List<DNSRecord>();
            foreach (var item in list)
            {
                if (item.QueryType <= 0) continue;

                var r = DNSEntity.CreateRecord((DNSQueryType)item.QueryType);
                r.Name = item.Name;
                if (r.Name[0] == '*') r.Name = r.Name.Substring(1);
                if (r.Name[0] == '.') r.Name = r.Name.Substring(1);
                r.Text = item.Address;
                // 生存时间3分钟
                r.TTL = new TimeSpan(0, 3, 0);
                drs.Add(r);

                item.Hits++;
                item.SaveAsync();
            }
            rs.Answers = drs.ToArray();

            return rs;
        }

        DNSEntity CheckRecord(DNSEntity dns)
        {
            var rq = dns.Questions[0];
            var list = Record.FindAllByQueryTypeAndName((Int32)rq.Type, rq.Name);
            if (list == null || list.Count == 0) return null;

            var rs = new DNSEntity();
            rs.Questions = dns.Questions;

            var drs = new List<DNSRecord>();
            var now = DateTime.Now;
            foreach (var item in list)
            {
                if (item.QueryType <= 0) continue;

                var r = DNSEntity.CreateRecord((DNSQueryType)item.QueryType);
                r.Name = item.Name;
                r.Text = item.Address;

                // 生产时间过期，并且最后更新时间也过期，才去更新
                if (item.TTL < now && item.Next < now)
                {
                    // 生存时间3分钟
                    r.TTL = new TimeSpan(0, 3, 0);

                    // 更新数据库记录，3分钟内不要再次去找
                    item.Next = now.AddMinutes(3);

                    item.Hits++;
                    item.SaveAsync();
                }
                else
                {
                    r.TTL = item.TTL - now;
                    drs.Add(r);
                }
            }
            // 没有任何满足条件的返回，让它去更新吧
            if (drs.Count < 1) return null;

            rs.Answers = drs.ToArray();

            return rs;
        }

        void Server_OnResponse(object sender, DNSEventArgs e)
        {
            var rs = e.Response;
            if (rs == null) return;

            var rq = rs.Questions[0];

            // 记录历史
            var hi = new History();
            hi.Type = (Int32)rq.Type;
            hi.Name = rq.Name;
            if (e.Session != null)
            {
                hi.UserIP = e.Session.Remote.EndPoint + "";
                hi.ProtocolType = e.Session.Remote.Type;
            }
            if (rs.Answers != null && rs.Answers.Length > 0)
            {
                //entity.Address = rs.Answers[0].Text;

                foreach (var item in rs.Answers)
                {
                    var dr = hi.CloneEntity(false);
                    dr.Type = (Int32)item.Type;
                    dr.Name = item.Name;
                    dr.Address = item.Text;
                    dr.Insert();
                }
            }
            else
                hi.Insert();

            // 记录访问者
            var vt = Visitor.Check(e.Session.Remote.Host);
            if (vt != null)
            {
                vt.LastDomainName = rq.Name;
                vt.Hits++;
                vt.LastVisit = DateTime.Now;
                // 单对象缓存会自动保存
            }
        }

        void Server_OnNew(object sender, DNSEventArgs e)
        {
            var rs = e.Response;
            if (rs == null || rs.Answers == null) return;

            var rq = rs.Questions[0];

            var now = DateTime.Now;
            foreach (var dr in rs.Answers)
            {
                var entity = Record.FindByQueryTypeAndNameAndAddress((Int32)dr.Type, rq.Name, dr.Text);
                if (entity == null)
                {
                    entity = new Record();
                    entity.Name = rq.Name;
                    entity.Type = (Int32)dr.Type;
                    entity.Address = dr.Text;
                }

                entity.TTL = now.Add(dr.TTL);
                entity.Parent = e.Session.Remote + "";
                entity.UpdateTime = DateTime.Now;

                entity.Save();
            }
        }
        #endregion
    }
}