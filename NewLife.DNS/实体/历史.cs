/*
 * XCoder v4.8.4559.21730
 * 作者：nnhy/NEWLIFE
 * 时间：2012-06-25 16:16:35
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
    /// <summary>历史</summary>
    [Serializable]
    [DataObject]
    [Description("历史")]
    [BindIndex("IX_History", true, "ID")]
    [BindIndex("PK_History", true, "ID")]
    [BindTable("History", Description = "历史", ConnName = "DNS", DbType = DatabaseType.SqlServer)]
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

        private String _UserIP;
        /// <summary>用户地址</summary>
        [DisplayName("用户地址")]
        [Description("用户地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "UserIP", "用户地址", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserIP
        {
            get { return _UserIP; }
            set { if (OnPropertyChanging("UserIP", value)) { _UserIP = value; OnPropertyChanged("UserIP"); } }
        }

        private Int32 _ProtocolType;
        /// <summary>协议</summary>
        [DisplayName("协议")]
        [Description("协议")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "ProtocolType", "协议", null, "int", 10, 0, false)]
        public virtual Int32 ProtocolType
        {
            get { return _ProtocolType; }
            set { if (OnPropertyChanging("ProtocolType", value)) { _ProtocolType = value; OnPropertyChanged("ProtocolType"); } }
        }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(7, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateTime
        {
            get { return _CreateTime; }
            set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } }
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
                    case "UserIP" : return _UserIP;
                    case "ProtocolType" : return _ProtocolType;
                    case "CreateTime" : return _CreateTime;
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
                    case "UserIP" : _UserIP = Convert.ToString(value); break;
                    case "ProtocolType" : _ProtocolType = Convert.ToInt32(value); break;
                    case "CreateTime" : _CreateTime = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得历史字段信息的快捷方式</summary>
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

            ///<summary>用户地址</summary>
            public static readonly Field UserIP = FindByName("UserIP");

            ///<summary>协议</summary>
            public static readonly Field ProtocolType = FindByName("ProtocolType");

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>历史接口</summary>
    public partial interface IHistory
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

        /// <summary>用户地址</summary>
        String UserIP { get; set; }

        /// <summary>协议</summary>
        Int32 ProtocolType { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}