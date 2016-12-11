using System;
using System.Collections.Generic;
using NewLife.Agent;
using NewLife.Configuration;
using NewLife.DNS;
using NewLife.DNS.Entity;
using NewLife.Net.DNS;

namespace XDNS
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
            ServiceName = "XDNS";
        }
        #endregion

        #region 核心
        public override bool Work(int index) { return false; }

        DNSServer Server;

        public override void StartWork()
        {
            Server = new DNSServer();
            Server.Parent = Config.GetConfig<String>("XDNS.Parent") + "," + Server.Parent;
            Server.OnRequest += new EventHandler<DNSEventArgs>(Server_OnRequest);
            Server.OnResponse += new EventHandler<DNSEventArgs>(Server_OnResponse);
            Server.OnNew += new EventHandler<DNSEventArgs>(Server_OnNew);
            Server.Start();

            base.StartWork();
        }

        public override void StopWork()
        {
            base.StopWork();

            Server.Stop();
            Server.OnRequest -= new EventHandler<DNSEventArgs>(Server_OnRequest);
            Server.OnResponse -= new EventHandler<DNSEventArgs>(Server_OnResponse);
            Server.OnNew -= new EventHandler<DNSEventArgs>(Server_OnNew);
        }
        #endregion

        #region 业务
        void Server_OnRequest(object sender, DNSEventArgs e)
        {
            var request = e.Request;
            if (request == null) return;

            var rq = request.Questions[0];

            // 查询规则
            var list = Rule.FindAllByQueryTypeAndName((Int32)rq.Type, rq.Name);
            if (list != null && list.Count > 0)
            {
                var rs = new DNSEntity();
                rs.Questions = request.Questions;
                var drs = new List<DNSRecord>();
                foreach (var item in list)
                {
                    if (item.QueryType <= 0) continue;

                    var r = DNSEntity.CreateRecord((DNSQueryType)item.QueryType);
                    r.Name = item.Name;
                    if (r.Name[0] == '*') r.Name = r.Name.Substring(1);
                    if (r.Name[0] == '.') r.Name = r.Name.Substring(1);
                    r.Text = item.Address;
                    // 生产时间3分钟
                    r.TTL = new TimeSpan(0, 3, 0);
                    drs.Add(r);

                    item.Hits++;
                    item.Update();
                }
                rs.Answers = drs.ToArray();

                e.Response = rs;
                return;
            }

            // 查询记录
            var list2 = Record.FindAllByQueryTypeAndName((Int32)rq.Type, rq.Name);
            if (list2 != null && list2.Count > 0)
            {
                var rs = new DNSEntity();
                rs.Questions = request.Questions;
                var drs = new List<DNSRecord>();
                var now = DateTime.Now;
                foreach (var item in list2)
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
                        item.Update();
                    }
                    else
                    {
                        r.TTL = item.TTL - now;
                        drs.Add(r);
                    }
                }
                // 没有任何满足条件的返回，让它去更新吧
                if (drs.Count < 1) return;

                rs.Answers = drs.ToArray();

                e.Response = rs;
                return;
            }
        }

        void Server_OnResponse(object sender, DNSEventArgs e)
        {
            var rs = e.Response;
            if (rs == null) return;

            var rq = rs.Questions[0];

            // 记录历史
            var entity = new History();
            entity.QueryType = (Int32)rq.Type;
            entity.Name = rq.Name;
            if (e.Session != null)
            {
                entity.UserIP = e.Session.Remote.EndPoint + "";
                entity.ProtocolType = e.Session.Remote.Type;
            }
            if (rs.Answers != null && rs.Answers.Length > 0)
            {
                //entity.Address = rs.Answers[0].Text;

                foreach (var item in rs.Answers)
                {
                    var dr = entity.CloneEntity(false);
                    dr.QueryType = (Int32)item.Type;
                    dr.Name = item.Name;
                    dr.Address = item.Text;
                    dr.Insert();
                }
            }
            else
                entity.Insert();

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
                    entity.QueryType = (Int32)dr.Type;
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