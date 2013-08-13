using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TechTalk.SpecLog.Common;

namespace SpecLog.HtmlExportPlugin.Server
{
    public interface IHtmlExportPluginConfiguration : IPeriodicActivityConfiguration
    {
        string OutputPath { get; }
    }

    [Serializable]
    public class HtmlExportPluginConfiguration : IHtmlExportPluginConfiguration
    {
        public string OutputPath { get; set; }

        public int GenerationIntervalMinutes { get; set; }

        [XmlIgnore]
        public TimeSpan TriggerInterval
        {
            get { return TimeSpan.FromMinutes(GenerationIntervalMinutes); }
        }
    }
}
