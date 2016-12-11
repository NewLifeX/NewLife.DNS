using System;
using System.Collections.Generic;
using System.Text;
using XCode;
using XCode.DataAccessLayer;
using System.Data.Common;
using System.IO;

namespace NewLife.DNS
{
    static class Helper
    {
        /// <summary>检查历史数据的数据库名。实现根据时间划分数据库</summary>
        /// <param name="eop">实体操作者</param>
        /// <param name="dt">时间依据</param>
        /// <param name="false">是否创建数据库</param>
        /// <returns></returns>
        public static Boolean CheckHistoryDatabase(IEntityOperate eop, DateTime dt, Boolean createDb = false)
        {
            // 根据时间计算数据库名
            //var name = String.Format("DNS_History_{0:yyMM}", dt);
            var name = String.Format("DNS_History_{0:yyyy}", dt);
            if (!DAL.ConnStrs.ContainsKey(name))
            {
                // 计算DNS数据库所在目录
                var builder = new DbConnectionStringBuilder();
                builder.ConnectionString = DAL.Create("DNS").ConnStr;

                var path = Path.GetDirectoryName(builder["Data Source"] + "");
                var file = Path.Combine(path, name + ".db");

                // 如果不创建数据库，并且文件不存在，则直接返回
                if (!createDb && !File.Exists(file.GetFullPath())) return false;

                // 再次判断，避免可能的冲突
                if (!DAL.ConnStrs.ContainsKey(name)) DAL.AddConnStr(name, String.Format("Data Source={0}", file), null, "SQLite");
            }

            // 切换数据库连接
            eop.ConnName = name;

            return true;
        }
    }
}