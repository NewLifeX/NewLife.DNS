﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace NewLife.DNS.Entity
{
    /// <summary>记录</summary>
    [Serializable]
    [DataObject]
    [Description("记录")]
    [BindIndex("IX_Record_Type", false, "Type")]
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
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private Int32 _Type;
        /// <summary>类型</summary>
        [DisplayName("类型")]
        [Description("类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "Type", "类型", null, "int", 10, 0, false)]
        public virtual Int32 Type
        {
            get { return _Type; }
            set { if (OnPropertyChanging(__.Type, value)) { _Type = value; OnPropertyChanged(__.Type); } }
        }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "Name", "名称", null, "nvarchar(50)", 0, 0, true, Master=true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private String _Address;
        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Address", "地址", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Address
        {
            get { return _Address; }
            set { if (OnPropertyChanging(__.Address, value)) { _Address = value; OnPropertyChanged(__.Address); } }
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
            set { if (OnPropertyChanging(__.TTL, value)) { _TTL = value; OnPropertyChanged(__.TTL); } }
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
            set { if (OnPropertyChanging(__.Parent, value)) { _Parent = value; OnPropertyChanged(__.Parent); } }
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
            set { if (OnPropertyChanging(__.Hits, value)) { _Hits = value; OnPropertyChanged(__.Hits); } }
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
            set { if (OnPropertyChanging(__.StatID, value)) { _StatID = value; OnPropertyChanged(__.StatID); } }
        }

        private DateTime _Next;
        /// <summary>下次更新</summary>
        [DisplayName("下次更新")]
        [Description("下次更新")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(9, "Next", "下次更新", null, "datetime", 3, 0, false)]
        public virtual DateTime Next
        {
            get { return _Next; }
            set { if (OnPropertyChanging(__.Next, value)) { _Next = value; OnPropertyChanged(__.Next); } }
        }

        private Int32 _CreateUserID;
        /// <summary>创建者</summary>
        [DisplayName("创建者")]
        [Description("创建者")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(10, "CreateUserID", "创建者", null, "int", 10, 0, false)]
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
        [BindColumn(11, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(12, "CreateIP", "创建地址", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(13, "UpdateUserID", "更新者", null, "int", 10, 0, false)]
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
        [BindColumn(14, "UpdateTime", "更新时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(15, "UpdateIP", "更新地址", null, "nvarchar(50)", 0, 0, true)]
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
                    case __.Type : return _Type;
                    case __.Name : return _Name;
                    case __.Address : return _Address;
                    case __.TTL : return _TTL;
                    case __.Parent : return _Parent;
                    case __.Hits : return _Hits;
                    case __.StatID : return _StatID;
                    case __.Next : return _Next;
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
                    case __.Type : _Type = Convert.ToInt32(value); break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.Address : _Address = Convert.ToString(value); break;
                    case __.TTL : _TTL = Convert.ToDateTime(value); break;
                    case __.Parent : _Parent = Convert.ToString(value); break;
                    case __.Hits : _Hits = Convert.ToInt32(value); break;
                    case __.StatID : _StatID = Convert.ToInt32(value); break;
                    case __.Next : _Next = Convert.ToDateTime(value); break;
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
        /// <summary>取得记录字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>编号</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>类型</summary>
            public static readonly Field Type = FindByName(__.Type);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>地址</summary>
            public static readonly Field Address = FindByName(__.Address);

            ///<summary>生存时间</summary>
            public static readonly Field TTL = FindByName(__.TTL);

            ///<summary>父级</summary>
            public static readonly Field Parent = FindByName(__.Parent);

            ///<summary>次数</summary>
            public static readonly Field Hits = FindByName(__.Hits);

            ///<summary>统计</summary>
            public static readonly Field StatID = FindByName(__.StatID);

            ///<summary>下次更新</summary>
            public static readonly Field Next = FindByName(__.Next);

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

        /// <summary>取得记录字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>编号</summary>
            public const String ID = "ID";

            ///<summary>类型</summary>
            public const String Type = "Type";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>地址</summary>
            public const String Address = "Address";

            ///<summary>生存时间</summary>
            public const String TTL = "TTL";

            ///<summary>父级</summary>
            public const String Parent = "Parent";

            ///<summary>次数</summary>
            public const String Hits = "Hits";

            ///<summary>统计</summary>
            public const String StatID = "StatID";

            ///<summary>下次更新</summary>
            public const String Next = "Next";

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

    /// <summary>记录接口</summary>
    public partial interface IRecord
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>类型</summary>
        Int32 Type { get; set; }

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

        /// <summary>下次更新</summary>
        DateTime Next { get; set; }

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