using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using TechTalk.SpecLog.Commands;
using TechTalk.SpecLog.Common;
using TechTalk.SpecLog.DataAccess.Boundaries;
using TechTalk.SpecLog.DataAccess.Repositories;
using TechTalk.SpecLog.Entities;
using TechTalk.SpecLog.HtmlExport;
using TechTalk.SpecLog.Server.Services.PluginInfrastructure;

namespace SpecLog.HtmlExportPlugin.Server
{
    [Plugin(HtmlExportPlugin.PluginName, ContainerSetupType = typeof(HtmlExportPluginContainerSetup))]
    public class HtmlExportPlugin : ServerPlugin
    {
        public const string PluginName = "SpecLog.HtmlExportPlugin";

        private readonly IHtmlExportPluginContainerSetup containerSetup;
        public HtmlExportPlugin(IHtmlExportPluginContainerSetup containerSetup)
        {
            this.containerSetup = containerSetup;
        }

        private IUnityContainer container;
        private IHtmlExportActivity htmlExportActivity;
        public override void OnStart()
        {
            var config = GetConfiguration<HtmlExportPluginConfiguration>();
            container = containerSetup.CreateContainer(config);

            htmlExportActivity = container.Resolve<IHtmlExportActivity>();
            htmlExportActivity.Start();

            Log(System.Diagnostics.TraceEventType.Information, "{0} started", PluginName);
        }

        public override void OnStop()
        {
            if (htmlExportActivity != null)
                htmlExportActivity.Stop();
            if (container != null)
                container.Dispose();

            htmlExportActivity = null;
            container = null;

            Log(System.Diagnostics.TraceEventType.Information, "{0} stopped", PluginName);
        }

        public override void PerformCommand(string commandVerb, string issuingUser)
        {
            // nop
        }

        public override IEnumerable<IPeriodicActivity> ActiveSynchronizers
        {
            get { return Enumerable.Empty<IPeriodicActivity>(); }
        }

        public override void AfterApplyCommand(RepositoryInfo repository, Command command)
        {
            // nop
        }

        public override void AfterUndoCommand(RepositoryInfo repository, Command command)
        {
            // nop
        }

        public override void BeforeApplyCommand(RepositoryInfo repository, Command command)
        {
            // nop
        }

        public override void BeforeUndoCommand(RepositoryInfo repository, Command command)
        {
            // nop
        }
    }
}
