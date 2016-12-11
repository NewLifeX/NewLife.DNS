using System;
using System.ComponentModel;
using NewLife.Xml;

namespace XDNS
{
    [XmlConfigFile("Config\\DNS.config", 15000)]
    public class Setting : XmlConfig<Setting>
    {
        /// <summary>上级DNS服务器</summary>
        [Description("上级DNS服务器")]
        public String DNSServer { get; set; } = "tcp://8.8.8.8,tcp://dns.newlifex.com";
    }
}