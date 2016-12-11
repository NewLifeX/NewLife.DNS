/*
 * XCoder v4.8.4559.21730
 * 作者：nnhy/NEWLIFE
 * 时间：2012-06-25 15:19:55
 * 版权：版权所有 (C) 新生命开发团队 2012
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using NewLife.Net;
using NewLife.Web;
using XCode;
using XCode.Cache;

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
        static History()
        {
            Meta.Table.DataTable.InsertOnly = true;

            var fact = Meta.Factory;
            Helper.CheckHistoryDatabase(fact, DateTime.Now, false);

            TypeCache.ConnName = fact.ConnName;
            NameCache.ConnName = fact.ConnName;
            UserCache.ConnName = fact.ConnName;
        }

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
        }

        public override Int32 Insert()
        {
            // 必须在Insert里面检查链接，因为OnInsert/Valid之前就会打开事务
            Helper.CheckHistoryDatabase(Meta.Factory, DateTime.Now, true);

            return base.Insert();
        }
        #endregion

        #region 扩展属性﻿
        /// <summary>DNS类型</summary>
        [Map(__.Type)]
        public QueryType QueryType { get { return (QueryType)Type; } set { Type = (Int32)value; } }

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
        public static EntityList<History> Search(Int32 type, String name, String user, DateTime start, DateTime end, String key, Pager p)
        {
            var dt = DateTime.Now;
            if (start > DateTime.MinValue)
                dt = start;
            else if (end > DateTime.MinValue)
                dt = end;
            if (!Helper.CheckHistoryDatabase(Meta.Factory, dt)) return new EntityList<History>();

            var exp = SearchWhereByKeys(key);

            if (type > 0) exp &= _.Type == type;
            if (!name.IsNullOrWhiteSpace()) exp &= _.Name == name;
            if (!user.IsNullOrWhiteSpace()) exp &= _.UserIP == user;

            // 因为分库存放，如果起始时间是1日，则忽略该条件
            if (start > DateTime.MinValue && start.Day > 1) exp &= _.CreateTime >= start;
            if (end > DateTime.MinValue) exp &= _.CreateTime < end.Date.AddDays(1);

            return FindAll(exp, p);
        }
        #endregion

        #region 扩展操作
        /// <summary>类型实体缓存，异步，缓存10分钟</summary>
        static FieldCache<History> TypeCache = new FieldCache<History>(_.Type);

        /// <summary>获取所有类型名称</summary>
        /// <returns></returns>
        public static IDictionary<String, String> FindAllTypes()
        {
            //return TypeCache.FindAllName();
            var list = TypeCache.Entities.ToList().Take(20).ToList();

            var dic = new Dictionary<String, String>();
            foreach (var entity in list)
            {
                var k = entity.Type;

                var v = "{0} ({1:n0})".F(entity.QueryType, entity.ID);
                dic[k + ""] = v;
            }
            return dic;
        }

        /// <summary>实体缓存，异步，缓存10分钟</summary>
        static FieldCache<History> NameCache = new FieldCache<History>(_.Name);

        /// <summary>获取所有名称</summary>
        /// <returns></returns>
        public static IDictionary<String, String> FindAllNames()
        {
            return NameCache.FindAllName();
        }

        /// <summary>实体缓存，异步，缓存10分钟</summary>
        static FieldCache<History> UserCache = new FieldCache<History>(_.UserIP);

        /// <summary>获取所有名称</summary>
        /// <returns></returns>
        public static IDictionary<String, String> FindAllUsers()
        {
            return UserCache.FindAllName();
        }
        #endregion

        #region 业务
        #endregion
    }
}