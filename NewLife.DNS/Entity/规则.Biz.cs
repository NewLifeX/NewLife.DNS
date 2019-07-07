/*
 * XCoder v4.8.4548.28140
 * 作者：nnhy/NEWLIFE
 * 时间：2012-06-18 11:08:42
 * 版权：版权所有 (C) 新生命开发团队 2012
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using NewLife.Log;
using NewLife.Web;
using XCode;
using XCode.Configuration;
using System.Net;
using System.Linq;

namespace NewLife.DNS.Entity
{
    /// <summary>规则</summary>
    public partial class Rule : Entity<Rule>
    {
        #region 对象操作﻿
        static Rule()
        {
            var df = Meta.Factory.AdditionalFields;
            df.Add(_.Hits);
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew"></param>
        public override void Valid(Boolean isNew)
        {
            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            //if (String.IsNullOrEmpty(Name)) throw new ArgumentNullException(_.Name, _.Name.DisplayName + "无效！");
            //if (!isNew && ID < 1) throw new ArgumentOutOfRangeException(_.ID, _.ID.DisplayName + "必须大于0！");

            // 建议先调用基类方法，基类方法会对唯一索引的数据进行验证
            base.Valid(isNew);

            // 在新插入数据或者修改了指定字段时进行唯一性验证，CheckExist内部抛出参数异常
            //if (isNew || Dirtys[_.Name]) CheckExist(_.Name);

            if (isNew && !Dirtys[_.CreateTime]) CreateTime = DateTime.Now;
            if (!Dirtys[_.UpdateTime]) UpdateTime = DateTime.Now;
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    base.InitData();

        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    // Meta.Count是快速取得表记录数
        //    if (Meta.Count > 0) return;

        //    // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}规则数据……", typeof(Rule).Name);

        //    var entity = new Rule();
        //    entity.Name = "abc";
        //    entity.Address = "abc";
        //    entity.StartTime = DateTime.Now;
        //    entity.EndTime = DateTime.Now;
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}规则数据！", typeof(Rule).Name);
        //}


        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        ///// <returns></returns>
        //protected override Int32 OnInsert()
        //{
        //    return base.OnInsert();
        //}
        #endregion

        #region 扩展属性﻿
        /// <summary>DNS类型</summary>
        [Map(__.Type)]
        public QueryType QueryType { get { return (QueryType)Type; } set { Type = (Int32)value; } }

        /// <summary>是否过期</summary>
        /// <returns></returns>
        public Boolean IsExpired
        {
            get
            {
                var now = DateTime.Now;

                if (StartDate > now.Date) return true;
                if (EndDate > DateTime.MinValue && EndDate < now.Date) return true;

                var mi = now.Hour * 60 + now.Minute;
                if (StartTime > mi) return true;
                if (EndTime > 0 && EndTime < mi) return true;

                return false;
            }
        }
        #endregion

        #region 扩展查询﻿
        /// <summary>根据记录类型、名称查找</summary>
        /// <param name="type">记录类型</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static IList<Rule> FindAllByQueryTypeAndName(Int32 type, String name)
        {
            var qtype = (QueryType)type;
            if (Meta.Count >= 1000)
            {
                var list = FindAll(GetWhere(qtype, name), null, null, 0, 0);
                if (list == null || list.Count < 1) return list;

                var now = DateTime.Now;
                //list.RemoveAll(e => e.IsExpired || !e.Enable);
                return list.Where(e => !e.IsExpired && e.Enable).ToList();
            }

            if (qtype != QueryType.ANY)
            {
                return Meta.Cache.Entities.FindAll(e => e.QueryType == qtype && e.Enable && !e.IsExpired && e.IsMatch(name));
            }
            else
            {
                return Meta.Cache.Entities.FindAll(e => !e.IsExpired && e.Enable && e.IsMatch(name));
            }
        }

        static String GetWhere(QueryType type, String name)
        {
            var exp = _.Name == name;
            if (type != QueryType.ANY) exp &= _.Type == type;

            return exp;
        }

        /// <summary>根据记录类型、名称、地址查找</summary>
        /// <param name="type">记录类型</param>
        /// <param name="name">名称</param>
        /// <param name="address">地址</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Rule FindByQueryTypeAndNameAndAddress(QueryType type, String name, String address)
        {
            if (Meta.Count >= 1000)
                return Find(new String[] { _.Type, _.Name, _.Address }, new Object[] { type, name, address });
            else // 实体缓存
                return Meta.Cache.Entities.Find(e => e.QueryType == type && e.Name == name && e.Address == address);
        }

        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Rule FindByID(Int32 id)
        {
            if (Meta.Count >= 1000)
                return Find(_.ID, id);
            else // 实体缓存
                return Meta.Cache.Entities.Find(e => e.ID == id);
            // 单对象缓存
            //return Meta.SingleCache[id];
        }
        #endregion

        #region 高级查询
        // 以下为自定义高级查询的例子

        ///// <summary>
        ///// 查询满足条件的记录集，分页、排序
        ///// </summary>
        ///// <param name="key">关键字</param>
        ///// <param name="orderClause">排序，不带Order By</param>
        ///// <param name="startRowIndex">开始行，0表示第一行</param>
        ///// <param name="maximumRows">最大返回行数，0表示所有行</param>
        ///// <returns>实体集</returns>
        //[DataObjectMethod(DataObjectMethodType.Select, true)]
        //public static IList<Rule> Search(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
        //{
        //    return FindAll(SearchWhere(key), orderClause, null, startRowIndex, maximumRows);
        //}

        ///// <summary>
        ///// 查询满足条件的记录总数，分页和排序无效，带参数是因为ObjectDataSource要求它跟Search统一
        ///// </summary>
        ///// <param name="key">关键字</param>
        ///// <param name="orderClause">排序，不带Order By</param>
        ///// <param name="startRowIndex">开始行，0表示第一行</param>
        ///// <param name="maximumRows">最大返回行数，0表示所有行</param>
        ///// <returns>记录数</returns>
        //public static Int32 SearchCount(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
        //{
        //    return FindCount(SearchWhere(key), null, null, 0, 0);
        //}

        /// <summary>构造搜索条件</summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        private static String SearchWhere(String key)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            var exp = new WhereExpression();

            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
            //if (!String.IsNullOrEmpty(key)) SearchWhereByKeys(exp.Builder, key);

            // 以下仅为演示，2、3行是同一个意思的不同写法，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
            //exp &= _.Name == "testName"
            //    & !String.IsNullOrEmpty(key) & _.Name == key
            //    .AndIf(!String.IsNullOrEmpty(key), _.Name == key)
            //    | _.ID > 0;

            return exp;
        }
        #endregion

        #region 扩展操作
        #endregion

        #region 业务
        /// <summary>是否匹配</summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Boolean IsMatch(String name)
        {
            if (String.IsNullOrEmpty(name)) return false;

            if (name.EqualIgnoreCase(Name)) return true;

            if (Name.Length > 1 && Name[0] == '*' && name.EndsWith(Name.Substring(1).Trim('.'), StringComparison.OrdinalIgnoreCase)) return true;

            return false;
        }

        public static Int32 Import(QueryType type, String name, String text)
        {
            var ss = text.Split(new Char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Int32 total = 0;
            Meta.BeginTrans();
            try
            {
                foreach (var item in ss)
                {
                    var myname = name.Trim();
                    var addr = item;
                    var p = addr.IndexOf(" ");
                    if (p < 0) p = addr.IndexOf("\t");
                    if (p > 0)
                    {
                        myname = addr.Substring(0, p).Trim();
                        addr = addr.Substring(p + 1).Trim();

                        IPAddress ip;
                        if (IPAddress.TryParse(myname, out ip))
                        {
                            myname = addr;
                            addr = ip.ToString();
                        }
                    }

                    var entity = FindByQueryTypeAndNameAndAddress(type, myname, addr);
                    if (entity != null) continue;

                    entity = new Rule();
                    entity.QueryType = type;
                    entity.Name = myname;
                    entity.Address = addr;
                    entity.Enable = true;
                    entity.Insert();

                    total++;
                }

                Meta.Commit();
            }
            catch { Meta.Rollback(); throw; }

            return total;
        }
        #endregion
    }
}