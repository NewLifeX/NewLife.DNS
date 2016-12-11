﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace NewLife.DNS.Entity
{
    /// <summary>历史</summary>
    [Serializable]
    [DataObject]
    [Description("历史")]
    [BindIndex("IX_History_Name", false, "Name")]
    [BindIndex("IX_History_Type", false, "Type")]
    [BindTable("History", Description = "历史", ConnName = "History", DbType = DatabaseType.SqlServer)]
    public partial class History : IHistory
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
        [DataObjectField(false, false, true, 200)]
        [BindColumn(4, "Address", "地址", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Address
        {
            get { return _Address; }
            set { if (OnPropertyChanging(__.Address, value)) { _Address = value; OnPropertyChanged(__.Address); } }
        }

        private String _UserIP;
        /// <summary>用户地址</summary>
        [DisplayName("用户地址")]
        [Description("用户地址")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(5, "UserIP", "用户地址", null, "nvarchar(200)", 0, 0, true)]
        public virtual String UserIP
        {
            get { return _UserIP; }
            set { if (OnPropertyChanging(__.UserIP, value)) { _UserIP = value; OnPropertyChanged(__.UserIP); } }
        }

        private Int32 _Protocol;
        /// <summary>协议</summary>
        [DisplayName("协议")]
        [Description("协议")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(6, "Protocol", "协议", null, "int", 10, 0, false)]
        public virtual Int32 Protocol
        {
            get { return _Protocol; }
            set { if (OnPropertyChanging(__.Protocol, value)) { _Protocol = value; OnPropertyChanged(__.Protocol); } }
        }

        private Int32 _CreateUserID;
        /// <summary>创建者</summary>
        [DisplayName("创建者")]
        [Description("创建者")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "CreateUserID", "创建者", null, "int", 10, 0, false)]
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
        [BindColumn(8, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
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
        [BindColumn(9, "CreateIP", "创建地址", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateIP
        {
            get { return _CreateIP; }
            set { if (OnPropertyChanging(__.CreateIP, value)) { _CreateIP = value; OnPropertyChanged(__.CreateIP); } }
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
                    case __.UserIP : return _UserIP;
                    case __.Protocol : return _Protocol;
                    case __.CreateUserID : return _CreateUserID;
                    case __.CreateTime : return _CreateTime;
                    case __.CreateIP : return _CreateIP;
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
                    case __.UserIP : _UserIP = Convert.ToString(value); break;
                    case __.Protocol : _Protocol = Convert.ToInt32(value); break;
                    case __.CreateUserID : _CreateUserID = Convert.ToInt32(value); break;
                    case __.CreateTime : _CreateTime = Convert.ToDateTime(value); break;
                    case __.CreateIP : _CreateIP = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得历史字段信息的快捷方式</summary>
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

            ///<summary>用户地址</summary>
            public static readonly Field UserIP = FindByName(__.UserIP);

            ///<summary>协议</summary>
            public static readonly Field Protocol = FindByName(__.Protocol);

            ///<summary>创建者</summary>
            public static readonly Field CreateUserID = FindByName(__.CreateUserID);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>创建地址</summary>
            public static readonly Field CreateIP = FindByName(__.CreateIP);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得历史字段名称的快捷方式</summary>
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

            ///<summary>用户地址</summary>
            public const String UserIP = "UserIP";

            ///<summary>协议</summary>
            public const String Protocol = "Protocol";

            ///<summary>创建者</summary>
            public const String CreateUserID = "CreateUserID";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>创建地址</summary>
            public const String CreateIP = "CreateIP";

        }
        #endregion
    }

    /// <summary>历史接口</summary>
    public partial interface IHistory
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

        /// <summary>用户地址</summary>
        String UserIP { get; set; }

        /// <summary>协议</summary>
        Int32 Protocol { get; set; }

        /// <summary>创建者</summary>
        Int32 CreateUserID { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>创建地址</summary>
        String CreateIP { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}