/*
 * XCoder v4.8.4559.21730
 * 作者：nnhy/NEWLIFE
 * 时间：2012-06-27 11:03:10
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
    /// <summary>访问者</summary>
    [Serializable]
    [DataObject]
    [Description("访问者")]
    [BindIndex("IX_Visitor", true, "Name")]
    [BindIndex("PK_Visitor", true, "ID")]
    [BindTable("Visitor", Description = "访问者", ConnName = "DNS", DbType = DatabaseType.SqlServer)]
    public partial class Visitor : IVisitor
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

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "Name", "名称", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } }
        }

        private Int32 _Hits;
        /// <summary>次数</summary>
        [DisplayName("次数")]
        [Description("次数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "Hits", "次数", null, "int", 10, 0, false)]
        public virtual Int32 Hits
        {
            get { return _Hits; }
            set { if (OnPropertyChanging("Hits", value)) { _Hits = value; OnPropertyChanged("Hits"); } }
        }

        private String _LastDomainName;
        /// <summary>最后域名</summary>
        [DisplayName("最后域名")]
        [Description("最后域名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "LastDomainName", "最后域名", null, "nvarchar(50)", 0, 0, true)]
        public virtual String LastDomainName
        {
            get { return _LastDomainName; }
            set { if (OnPropertyChanging("LastDomainName", value)) { _LastDomainName = value; OnPropertyChanged("LastDomainName"); } }
        }

        private DateTime _LastVisit;
        /// <summary>最后访问</summary>
        [DisplayName("最后访问")]
        [Description("最后访问")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "LastVisit", "最后访问", null, "datetime", 3, 0, false)]
        public virtual DateTime LastVisit
        {
            get { return _LastVisit; }
            set { if (OnPropertyChanging("LastVisit", value)) { _LastVisit = value; OnPropertyChanged("LastVisit"); } }
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
                    case "Name" : return _Name;
                    case "Hits" : return _Hits;
                    case "LastDomainName" : return _LastDomainName;
                    case "LastVisit" : return _LastVisit;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID" : _ID = Convert.ToInt32(value); break;
                    case "Name" : _Name = Convert.ToString(value); break;
                    case "Hits" : _Hits = Convert.ToInt32(value); break;
                    case "LastDomainName" : _LastDomainName = Convert.ToString(value); break;
                    case "LastVisit" : _LastVisit = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得访问者字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            ///<summary>次数</summary>
            public static readonly Field Hits = FindByName("Hits");

            ///<summary>最后域名</summary>
            public static readonly Field LastDomainName = FindByName("LastDomainName");

            ///<summary>最后访问</summary>
            public static readonly Field LastVisit = FindByName("LastVisit");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>访问者接口</summary>
    public partial interface IVisitor
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>次数</summary>
        Int32 Hits { get; set; }

        /// <summary>最后域名</summary>
        String LastDomainName { get; set; }

        /// <summary>最后访问</summary>
        DateTime LastVisit { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}