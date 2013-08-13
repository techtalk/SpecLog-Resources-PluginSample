using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TechTalk.SpecLog.Common;

namespace SpecLog.HtmlExportPlugin.Server
{
    [Serializable]
    public class HtmlExportPluginConfiguration
    {
        public string OutputPath { get; set; }

        public int GenerationIntervalMinutes { get; set; }

        [XmlIgnore]
        public TimeSpan GenerationInterval
        {
            get { return TimeSpan.FromMinutes(GenerationIntervalMinutes); }
        }
    }
}
