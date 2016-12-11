/*
 * XCoder v4.8.4559.21730
 * 作者：nnhy/NEWLIFE
 * 时间：2012-06-27 12:13:51
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
    /// <summary>规则</summary>
    [Serializable]
    [DataObject]
    [Description("规则")]
    [BindIndex("IX_Rule", false, "QueryType,Name")]
    [BindIndex("IX_Rule_1", true, "QueryType,Name,Address")]
    [BindIndex("PK__Rule", true, "ID")]
    [BindTable("Rule", Description = "规则", ConnName = "DNS", DbType = DatabaseType.SqlServer)]
    public partial class Rule : IRule
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

        private DateTime _StartDate;
        /// <summary>开始日期</summary>
        [DisplayName("开始日期")]
        [Description("开始日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "StartDate", "开始日期", null, "datetime", 3, 0, false)]
        public virtual DateTime StartDate
        {
            get { return _StartDate; }
            set { if (OnPropertyChanging("StartDate", value)) { _StartDate = value; OnPropertyChanged("StartDate"); } }
        }

        private DateTime _EndDate;
        /// <summary>结束日期</summary>
        [DisplayName("结束日期")]
        [Description("结束日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(6, "EndDate", "结束日期", null, "datetime", 3, 0, false)]
        public virtual DateTime EndDate
        {
            get { return _EndDate; }
            set { if (OnPropertyChanging("EndDate", value)) { _EndDate = value; OnPropertyChanged("EndDate"); } }
        }

        private Int32 _StartTime;
        /// <summary>开始时间</summary>
        [DisplayName("开始时间")]
        [Description("开始时间")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "StartTime", "开始时间", null, "int", 10, 0, false)]
        public virtual Int32 StartTime
        {
            get { return _StartTime; }
            set { if (OnPropertyChanging("StartTime", value)) { _StartTime = value; OnPropertyChanged("StartTime"); } }
        }

        private Int32 _EndTime;
        /// <summary>结束时间</summary>
        [DisplayName("结束时间")]
        [Description("结束时间")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "EndTime", "结束时间", null, "int", 10, 0, false)]
        public virtual Int32 EndTime
        {
            get { return _EndTime; }
            set { if (OnPropertyChanging("EndTime", value)) { _EndTime = value; OnPropertyChanged("EndTime"); } }
        }

        private Boolean _IsEnable;
        /// <summary>是否启用</summary>
        [DisplayName("是否启用")]
        [Description("是否启用")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(9, "IsEnable", "是否启用", null, "bit", 0, 0, false)]
        public virtual Boolean IsEnable
        {
            get { return _IsEnable; }
            set { if (OnPropertyChanging("IsEnable", value)) { _IsEnable = value; OnPropertyChanged("IsEnable"); } }
        }

        private Int32 _Hits;
        /// <summary>次数</summary>
        [DisplayName("次数")]
        [Description("次数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(10, "Hits", "次数", null, "int", 10, 0, false)]
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
        [BindColumn(11, "StatID", "统计", null, "int", 10, 0, false)]
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
        [BindColumn(12, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(13, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
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
                    case "StartDate" : return _StartDate;
                    case "EndDate" : return _EndDate;
                    case "StartTime" : return _StartTime;
                    case "EndTime" : return _EndTime;
                    case "IsEnable" : return _IsEnable;
                    case "Hits" : return _Hits;
                    case "StatID" : return _StatID;
                    case "CreateTime" : return _CreateTime;
                    case "UpdateTime" : return _UpdateTime;
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
                    case "StartDate" : _StartDate = Convert.ToDateTime(value); break;
                    case "EndDate" : _EndDate = Convert.ToDateTime(value); break;
                    case "StartTime" : _StartTime = Convert.ToInt32(value); break;
                    case "EndTime" : _EndTime = Convert.ToInt32(value); break;
                    case "IsEnable" : _IsEnable = Convert.ToBoolean(value); break;
                    case "Hits" : _Hits = Convert.ToInt32(value); break;
                    case "StatID" : _StatID = Convert.ToInt32(value); break;
                    case "CreateTime" : _CreateTime = Convert.ToDateTime(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得规则字段信息的快捷方式</summary>
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

            ///<summary>开始日期</summary>
            public static readonly Field StartDate = FindByName("StartDate");

            ///<summary>结束日期</summary>
            public static readonly Field EndDate = FindByName("EndDate");

            ///<summary>开始时间</summary>
            public static readonly Field StartTime = FindByName("StartTime");

            ///<summary>结束时间</summary>
            public static readonly Field EndTime = FindByName("EndTime");

            ///<summary>是否启用</summary>
            public static readonly Field IsEnable = FindByName("IsEnable");

            ///<summary>次数</summary>
            public static readonly Field Hits = FindByName("Hits");

            ///<summary>统计</summary>
            public static readonly Field StatID = FindByName("StatID");

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>规则接口</summary>
    public partial interface IRule
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

        /// <summary>开始日期</summary>
        DateTime StartDate { get; set; }

        /// <summary>结束日期</summary>
        DateTime EndDate { get; set; }

        /// <summary>开始时间</summary>
        Int32 StartTime { get; set; }

        /// <summary>结束时间</summary>
        Int32 EndTime { get; set; }

        /// <summary>是否启用</summary>
        Boolean IsEnable { get; set; }

        /// <summary>次数</summary>
        Int32 Hits { get; set; }

        /// <summary>统计</summary>
        Int32 StatID { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}