using System;
using System.ComponentModel;
using NewLife.Xml;

namespace NewLife.DNS.Server
{
    [XmlConfigFile("Config\\DNS.config", 15000)]
    public class Setting : XmlConfig<Setting>
    {
        /// <summary>调试，默认true</summary>
        [Description("调试，默认true")]
        public Boolean Debug { get; set; } = true;

        /// <summary>上级DNS服务器</summary>
        [Description("上级DNS服务器")]
        public String DNSServer { get; set; } = "udp://223.5.5.5,tcp://8.8.8.8,udp://223.4.4.4";
    }
}