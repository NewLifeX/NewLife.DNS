/*
 * XCoder v4.8.4559.21730
 * 作者：nnhy/NEWLIFE
 * 时间：2012-06-27 11:14:06
 * 版权：版权所有 (C) 新生命开发团队 2012
*/
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace NewLife.DNS
{
    /// <summary>记录</summary>
    [Serializable]
    [DataObject]
    [Description("记录")]
    [BindIndex("IX_Record", false, "QueryType,Name")]
    [BindIndex("IX_Record_1", false, "QueryType,Address")]
    [BindIndex("IX_Record_2", true, "QueryType,Name,Address")]
    [BindIndex("PK__Record", true, "ID")]
    [BindTable("Record", Description = "记录", ConnName = "DNS", DbType = DatabaseType.SqlServer)]
    public partial class Record : IRecord
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "编号", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } }
        }

        private Int32 _QueryType;
        /// <summary>记录类型</summary>
        [DisplayName("记录类型")]
        [Description("记录类型")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "QueryType", "记录类型", null, "int", 10, 0, false)]
        public virtual Int32 QueryType
        {
            get { return _QueryType; }
            set { if (OnPropertyChanging("QueryType", value)) { _QueryType = value; OnPropertyChanged("QueryType"); } }
        }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 100)]
        [BindColumn(3, "Name", "名称", null, "nvarchar(100)", 0, 0, true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } }
        }

        private String _Address;
        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, false, 200)]
        [BindColumn(4, "Address", "地址", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Address
        {
            get { return _Address; }
            set { if (OnPropertyChanging("Address", value)) { _Address = value; OnPropertyChanged("Address"); } }
        }

        private DateTime _TTL;
        /// <summary>生存时间</summary>
        [DisplayName("生存时间")]
        [Description("生存时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "TTL", "生存时间", null, "datetime", 3, 0, false)]
        public virtual DateTime TTL
        {
            get { return _TTL; }
            set { if (OnPropertyChanging("TTL", value)) { _TTL = value; OnPropertyChanged("TTL"); } }
        }

        private String _Parent;
        /// <summary>父级</summary>
        [DisplayName("父级")]
        [Description("父级")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "Parent", "父级", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Parent
        {
            get { return _Parent; }
            set { if (OnPropertyChanging("Parent", value)) { _Parent = value; OnPropertyChanged("Parent"); } }
        }

        private Int32 _Hits;
        /// <summary>次数</summary>
        [DisplayName("次数")]
        [Description("次数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "Hits", "次数", null, "int", 10, 0, false)]
        public virtual Int32 Hits
        {
            get { return _Hits; }
            set { if (OnPropertyChanging("Hits", value)) { _Hits = value; OnPropertyChanged("Hits"); } }
        }

        private Int32 _StatID;
        /// <summary>统计</summary>
        [DisplayName("统计")]
        [Description("统计")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "StatID", "统计", null, "int", 10, 0, false)]
        public virtual Int32 StatID
        {
            get { return _StatID; }
            set { if (OnPropertyChanging("StatID", value)) { _StatID = value; OnPropertyChanged("StatID"); } }
        }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(9, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateTime
        {
            get { return _CreateTime; }
            set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(10, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
        }

        private DateTime _LastUpdate;
        /// <summary>最后更新</summary>
        [DisplayName("最后更新")]
        [Description("最后更新")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(11, "LastUpdate", "最后更新", null, "datetime", 3, 0, false)]
        public virtual DateTime LastUpdate
        {
            get { return _LastUpdate; }
            set { if (OnPropertyChanging("LastUpdate", value)) { _LastUpdate = value; OnPropertyChanged("LastUpdate"); } }
        }
		#endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case "ID" : return _ID;
                    case "QueryType" : return _QueryType;
                    case "Name" : return _Name;
                    case "Address" : return _Address;
                    case "TTL" : return _TTL;
                    case "Parent" : return _Parent;
                    case "Hits" : return _Hits;
                    case "StatID" : return _StatID;
                    case "CreateTime" : return _CreateTime;
                    case "UpdateTime" : return _UpdateTime;
                    case "LastUpdate" : return _LastUpdate;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID" : _ID = Convert.ToInt32(value); break;
                    case "QueryType" : _QueryType = Convert.ToInt32(value); break;
                    case "Name" : _Name = Convert.ToString(value); break;
                    case "Address" : _Address = Convert.ToString(value); break;
                    case "TTL" : _TTL = Convert.ToDateTime(value); break;
                    case "Parent" : _Parent = Convert.ToString(value); break;
                    case "Hits" : _Hits = Convert.ToInt32(value); break;
                    case "StatID" : _StatID = Convert.ToInt32(value); break;
                    case "CreateTime" : _CreateTime = Convert.ToDateTime(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
                    case "LastUpdate" : _LastUpdate = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得记录字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            ///<summary>记录类型</summary>
            public static readonly Field QueryType = FindByName("QueryType");

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            ///<summary>地址</summary>
            public static readonly Field Address = FindByName("Address");

            ///<summary>生存时间</summary>
            public static readonly Field TTL = FindByName("TTL");

            ///<summary>父级</summary>
            public static readonly Field Parent = FindByName("Parent");

            ///<summary>次数</summary>
            public static readonly Field Hits = FindByName("Hits");

            ///<summary>统计</summary>
            public static readonly Field StatID = FindByName("StatID");

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            ///<summary>最后更新</summary>
            public static readonly Field LastUpdate = FindByName("LastUpdate");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>记录接口</summary>
    public partial interface IRecord
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>记录类型</summary>
        Int32 QueryType { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>地址</summary>
        String Address { get; set; }

        /// <summary>生存时间</summary>
        DateTime TTL { get; set; }

        /// <summary>父级</summary>
        String Parent { get; set; }

        /// <summary>次数</summary>
        Int32 Hits { get; set; }

        /// <summary>统计</summary>
        Int32 StatID { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>最后更新</summary>
        DateTime LastUpdate { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}