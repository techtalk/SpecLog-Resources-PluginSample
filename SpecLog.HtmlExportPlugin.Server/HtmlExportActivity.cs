using System;
using TechTalk.SpecLog.Common;
using TechTalk.SpecLog.Entities;

namespace SpecLog.HtmlExportPlugin.Server
{
    public interface IHtmlExportActivity : IPeriodicActivity { }

    public class HtmlExportActivity : PeriodicActivity, IHtmlExportActivity
    {
        private readonly string outputPath;
        public HtmlExportActivity(ITimeService timeService, IHtmlExportPluginConfiguration htmlExportPluginConfiguration)
            : base(timeService, htmlExportPluginConfiguration)
        {
            outputPath = htmlExportPluginConfiguration.OutputPath;
        }

        protected override bool TriggerAction()
        {
            //TODO: html export
            throw new NotImplementedException();
        }
    }
}
