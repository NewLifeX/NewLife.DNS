/*
 * XCoder v4.8.4559.21730
 * 作者：nnhy/NEWLIFE
 * 时间：2012-06-25 15:19:55
 * 版权：版权所有 (C) 新生命开发团队 2012
*/
using System;
using System.ComponentModel;
using System.Net.Sockets;
using NewLife.Net;
using NewLife.Web;
using XCode;

namespace NewLife.DNS.Entity
{
    /// <summary>历史</summary>
    [BindIndex("IX_History_Name", false, "Name")]
    [BindIndex("IX_History_Address", false, "Address")]
    [BindIndex("IX_History_CreateTime", false, "CreateTime")]
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public partial class History : Entity<History>
    {
        #region 对象操作﻿
        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew"></param>
        public override void Valid(Boolean isNew)
        {
            // 建议先调用基类方法，基类方法会对唯一索引的数据进行验证
            base.Valid(isNew);

            //if (!Dirtys[_.UserIP]) UserIP = WebHelper.UserHost;
            if (isNew && !Dirtys[_.CreateTime]) CreateTime = DateTime.Now;

            // 把\0干掉
            if (Dirtys[_.Name]) Name = (Name + "").Replace("\0", "");

            Helper.CheckHistoryDatabase(Meta.Factory, DateTime.Now, true);
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
        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}历史数据……", typeof(History).Name);

        //    var entity = new History();
        //    entity.QueryType = 0;
        //    entity.Name = "abc";
        //    entity.Address = "abc";
        //    entity.UserIP = "abc";
        //    entity.CreateTime = DateTime.Now;
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}历史数据！", typeof(History).Name);
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
        public QueryType DNSQueryType { get { return (QueryType)QueryType; } set { QueryType = (Int32)value; } }

        /// <summary>协议类型</summary>
        [Map(__.Protocol)]
        public NetType ProtocolType { get { return (NetType)Protocol; } set { Protocol = (Int32)value; } }
        #endregion

        #region 扩展查询﻿
        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static History FindByID(Int32 id)
        {
            if (Meta.Count >= 1000)
                return Find(_.ID, id);
            else // 实体缓存
                return Meta.Cache.Entities.Find(_.ID, id);
            // 单对象缓存
            //return Meta.SingleCache[id];
        }
        #endregion

        #region 高级查询
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static EntityList<History> Search(String name, String address, DateTime start, DateTime end, String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
        {
            var dt = DateTime.Now;
            if (start > DateTime.MinValue)
                dt = start;
            else if (end > DateTime.MinValue)
                dt = end;
            if (!Helper.CheckHistoryDatabase(Meta.Factory, dt)) return new EntityList<History>();

            return FindAll(SearchWhere(name, address, start, end, key), orderClause, null, startRowIndex, maximumRows);
        }

        public static Int32 SearchCount(String name, String address, DateTime start, DateTime end, String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
        {
            var dt = DateTime.Now;
            if (start > DateTime.MinValue)
                dt = start;
            else if (end > DateTime.MinValue)
                dt = end;
            if (!Helper.CheckHistoryDatabase(Meta.Factory, dt)) return 0;

            return FindCount(SearchWhere(name, address, start, end, key), null, null, 0, 0);
        }

        private static String SearchWhere(String name, String address, DateTime start, DateTime end, String key)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            var exp = SearchWhereByKeys(key);

            if (!name.IsNullOrWhiteSpace()) exp &= _.Name == name;
            if (!address.IsNullOrWhiteSpace()) exp &= _.Address == address;

            // 因为分库存放，如果起始时间是1日，则忽略该条件
            if (start > DateTime.MinValue && start.Day > 1) exp &= _.CreateTime >= start;
            if (end > DateTime.MinValue) exp &= _.CreateTime < end.Date.AddDays(1);

            return exp;
        }
        #endregion

        #region 扩展操作
        #endregion

        #region 业务
        #endregion
    }
}