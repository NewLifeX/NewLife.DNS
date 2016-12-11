﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace NewLife.DNS.Entity
{
    /// <summary>规则</summary>
    [Serializable]
    [DataObject]
    [Description("规则")]
    [BindIndex("IX_Rule_Name", false, "Name")]
    [BindIndex("IX_Rule_Type", false, "Type")]
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
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "Name", "名称", null, "nvarchar(50)", 0, 0, true, Master=true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private Int32 _Type;
        /// <summary>类型</summary>
        [DisplayName("类型")]
        [Description("类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "Type", "类型", null, "int", 10, 0, false)]
        public virtual Int32 Type
        {
            get { return _Type; }
            set { if (OnPropertyChanging(__.Type, value)) { _Type = value; OnPropertyChanged(__.Type); } }
        }

        private String _Address;
        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(4, "Address", "地址", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Address
        {
            get { return _Address; }
            set { if (OnPropertyChanging(__.Address, value)) { _Address = value; OnPropertyChanged(__.Address); } }
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
            set { if (OnPropertyChanging(__.StartDate, value)) { _StartDate = value; OnPropertyChanged(__.StartDate); } }
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
            set { if (OnPropertyChanging(__.EndDate, value)) { _EndDate = value; OnPropertyChanged(__.EndDate); } }
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
            set { if (OnPropertyChanging(__.StartTime, value)) { _StartTime = value; OnPropertyChanged(__.StartTime); } }
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
            set { if (OnPropertyChanging(__.EndTime, value)) { _EndTime = value; OnPropertyChanged(__.EndTime); } }
        }

        private Boolean _Enable;
        /// <summary>启用</summary>
        [DisplayName("启用")]
        [Description("启用")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(9, "Enable", "启用", null, "bit", 0, 0, false)]
        public virtual Boolean Enable
        {
            get { return _Enable; }
            set { if (OnPropertyChanging(__.Enable, value)) { _Enable = value; OnPropertyChanged(__.Enable); } }
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
            set { if (OnPropertyChanging(__.Hits, value)) { _Hits = value; OnPropertyChanged(__.Hits); } }
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
            set { if (OnPropertyChanging(__.StatID, value)) { _StatID = value; OnPropertyChanged(__.StatID); } }
        }

        private Int32 _CreateUserID;
        /// <summary>创建者</summary>
        [DisplayName("创建者")]
        [Description("创建者")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(12, "CreateUserID", "创建者", null, "int", 10, 0, false)]
        public virtual Int32 CreateUserID
        {
            get { return _CreateUserID; }
            set { if (OnPropertyChanging(__.CreateUserID, value)) { _CreateUserID = value; OnPropertyChanged(__.CreateUserID); } }
        }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(13, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateTime
        {
            get { return _CreateTime; }
            set { if (OnPropertyChanging(__.CreateTime, value)) { _CreateTime = value; OnPropertyChanged(__.CreateTime); } }
        }

        private String _CreateIP;
        /// <summary>创建地址</summary>
        [DisplayName("创建地址")]
        [Description("创建地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "CreateIP", "创建地址", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateIP
        {
            get { return _CreateIP; }
            set { if (OnPropertyChanging(__.CreateIP, value)) { _CreateIP = value; OnPropertyChanged(__.CreateIP); } }
        }

        private Int32 _UpdateUserID;
        /// <summary>更新者</summary>
        [DisplayName("更新者")]
        [Description("更新者")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(15, "UpdateUserID", "更新者", null, "int", 10, 0, false)]
        public virtual Int32 UpdateUserID
        {
            get { return _UpdateUserID; }
            set { if (OnPropertyChanging(__.UpdateUserID, value)) { _UpdateUserID = value; OnPropertyChanged(__.UpdateUserID); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(16, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging(__.UpdateTime, value)) { _UpdateTime = value; OnPropertyChanged(__.UpdateTime); } }
        }

        private String _UpdateIP;
        /// <summary>更新地址</summary>
        [DisplayName("更新地址")]
        [Description("更新地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(17, "UpdateIP", "更新地址", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UpdateIP
        {
            get { return _UpdateIP; }
            set { if (OnPropertyChanging(__.UpdateIP, value)) { _UpdateIP = value; OnPropertyChanged(__.UpdateIP); } }
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
                    case __.ID : return _ID;
                    case __.Name : return _Name;
                    case __.Type : return _Type;
                    case __.Address : return _Address;
                    case __.StartDate : return _StartDate;
                    case __.EndDate : return _EndDate;
                    case __.StartTime : return _StartTime;
                    case __.EndTime : return _EndTime;
                    case __.Enable : return _Enable;
                    case __.Hits : return _Hits;
                    case __.StatID : return _StatID;
                    case __.CreateUserID : return _CreateUserID;
                    case __.CreateTime : return _CreateTime;
                    case __.CreateIP : return _CreateIP;
                    case __.UpdateUserID : return _UpdateUserID;
                    case __.UpdateTime : return _UpdateTime;
                    case __.UpdateIP : return _UpdateIP;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.Type : _Type = Convert.ToInt32(value); break;
                    case __.Address : _Address = Convert.ToString(value); break;
                    case __.StartDate : _StartDate = Convert.ToDateTime(value); break;
                    case __.EndDate : _EndDate = Convert.ToDateTime(value); break;
                    case __.StartTime : _StartTime = Convert.ToInt32(value); break;
                    case __.EndTime : _EndTime = Convert.ToInt32(value); break;
                    case __.Enable : _Enable = Convert.ToBoolean(value); break;
                    case __.Hits : _Hits = Convert.ToInt32(value); break;
                    case __.StatID : _StatID = Convert.ToInt32(value); break;
                    case __.CreateUserID : _CreateUserID = Convert.ToInt32(value); break;
                    case __.CreateTime : _CreateTime = Convert.ToDateTime(value); break;
                    case __.CreateIP : _CreateIP = Convert.ToString(value); break;
                    case __.UpdateUserID : _UpdateUserID = Convert.ToInt32(value); break;
                    case __.UpdateTime : _UpdateTime = Convert.ToDateTime(value); break;
                    case __.UpdateIP : _UpdateIP = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得规则字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>编号</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>类型</summary>
            public static readonly Field Type = FindByName(__.Type);

            ///<summary>地址</summary>
            public static readonly Field Address = FindByName(__.Address);

            ///<summary>开始日期</summary>
            public static readonly Field StartDate = FindByName(__.StartDate);

            ///<summary>结束日期</summary>
            public static readonly Field EndDate = FindByName(__.EndDate);

            ///<summary>开始时间</summary>
            public static readonly Field StartTime = FindByName(__.StartTime);

            ///<summary>结束时间</summary>
            public static readonly Field EndTime = FindByName(__.EndTime);

            ///<summary>启用</summary>
            public static readonly Field Enable = FindByName(__.Enable);

            ///<summary>次数</summary>
            public static readonly Field Hits = FindByName(__.Hits);

            ///<summary>统计</summary>
            public static readonly Field StatID = FindByName(__.StatID);

            ///<summary>创建者</summary>
            public static readonly Field CreateUserID = FindByName(__.CreateUserID);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>创建地址</summary>
            public static readonly Field CreateIP = FindByName(__.CreateIP);

            ///<summary>更新者</summary>
            public static readonly Field UpdateUserID = FindByName(__.UpdateUserID);

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            ///<summary>更新地址</summary>
            public static readonly Field UpdateIP = FindByName(__.UpdateIP);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得规则字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>编号</summary>
            public const String ID = "ID";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>类型</summary>
            public const String Type = "Type";

            ///<summary>地址</summary>
            public const String Address = "Address";

            ///<summary>开始日期</summary>
            public const String StartDate = "StartDate";

            ///<summary>结束日期</summary>
            public const String EndDate = "EndDate";

            ///<summary>开始时间</summary>
            public const String StartTime = "StartTime";

            ///<summary>结束时间</summary>
            public const String EndTime = "EndTime";

            ///<summary>启用</summary>
            public const String Enable = "Enable";

            ///<summary>次数</summary>
            public const String Hits = "Hits";

            ///<summary>统计</summary>
            public const String StatID = "StatID";

            ///<summary>创建者</summary>
            public const String CreateUserID = "CreateUserID";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>创建地址</summary>
            public const String CreateIP = "CreateIP";

            ///<summary>更新者</summary>
            public const String UpdateUserID = "UpdateUserID";

            ///<summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            ///<summary>更新地址</summary>
            public const String UpdateIP = "UpdateIP";

        }
        #endregion
    }

    /// <summary>规则接口</summary>
    public partial interface IRule
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>类型</summary>
        Int32 Type { get; set; }

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

        /// <summary>启用</summary>
        Boolean Enable { get; set; }

        /// <summary>次数</summary>
        Int32 Hits { get; set; }

        /// <summary>统计</summary>
        Int32 StatID { get; set; }

        /// <summary>创建者</summary>
        Int32 CreateUserID { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>创建地址</summary>
        String CreateIP { get; set; }

        /// <summary>更新者</summary>
        Int32 UpdateUserID { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>更新地址</summary>
        String UpdateIP { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}