/*
 * XCoder v4.8.4548.28140
 * 作者：nnhy/NEWLIFE
 * 时间：2012-06-18 11:08:38
 * 版权：版权所有 (C) 新生命开发团队 2012
*/
﻿using System;
using System.ComponentModel;
using XCode;

namespace NewLife.DNS
{
    /// <summary>记录</summary>
    public partial class Record : Entity<Record>
    {
        #region 对象操作﻿
        static Record()
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
            //if (!Dirtys[_.UpdateTime]) UpdateTime = DateTime.Now;
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
        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}记录数据……", typeof(Record).Name);

        //    var entity = new Record();
        //    entity.QueryType = 0;
        //    entity.Name = "abc";
        //    entity.Address = "abc";
        //    entity.Ttl = DateTime.Now;
        //    entity.Hits = 0;
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}记录数据！", typeof(Record).Name);
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
        /// <summary>属性说明</summary>
        public QueryType DNSQueryType { get { return (QueryType)QueryType; } set { QueryType = (Int32)value; } }
        #endregion

        #region 扩展查询﻿
        /// <summary>根据记录类型、名称查找</summary>
        /// <param name="querytype">记录类型</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<Record> FindAllByQueryTypeAndName(Int32 querytype, String name)
        {
            //if (Meta.Count >= 1000)
            //    return FindAll(new String[] { _.QueryType, _.Name }, new Object[] { querytype, name });
            //else // 实体缓存
            //    return Meta.Cache.Entities.FindAll(e => e.QueryType == querytype && e.Name == name);

            if ((QueryType)querytype != NewLife.DNS.QueryType.ANY)
            {
                if (Meta.Count >= 1000)
                    return FindAll(new String[] { _.QueryType, _.Name }, new Object[] { querytype, name });
                else // 实体缓存
                    return Meta.Cache.Entities.FindAll(e => e.QueryType == querytype && e.Name == name);
            }
            else
            {
                if (Meta.Count >= 1000)
                    return FindAll(_.Name, querytype);
                else // 实体缓存
                    return Meta.Cache.Entities.FindAll(e => e.Name == name);
            }
        }

        /// <summary>根据记录类型、地址查找</summary>
        /// <param name="querytype">记录类型</param>
        /// <param name="address">地址</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<Record> FindAllByQueryTypeAndAddress(Int32 querytype, String address)
        {
            if (Meta.Count >= 1000)
                return FindAll(new String[] { _.QueryType, _.Address }, new Object[] { querytype, address });
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(e => e.QueryType == querytype && e.Address == address);
        }

        /// <summary>根据记录类型、名称、地址查找</summary>
        /// <param name="querytype">记录类型</param>
        /// <param name="name">名称</param>
        /// <param name="address">地址</param>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Record FindByQueryTypeAndNameAndAddress(Int32 querytype, String name, String address)
        {
            return Find(new String[] { _.QueryType, _.Name, _.Address }, new Object[] { querytype, name, address });
        }

        /// <summary>根据ID查找</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Record FindByID(Int32 id)
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
        //public static EntityList<Record> Search(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
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
            var exp = SearchWhereByKeys(key);

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
        #endregion
    }
}