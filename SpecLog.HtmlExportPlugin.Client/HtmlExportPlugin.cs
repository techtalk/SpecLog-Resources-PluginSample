using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecLog.Application.Common.Dialogs;
using TechTalk.SpecLog.Application.Common.PluginsInfrastructure;
using TechTalk.SpecLog.Common;
using TechTalk.SpecLog.Entities;

namespace SpecLog.HtmlExportPlugin.Client
{
    [Plugin(HtmlExportPlugin.PluginName)]
    public class HtmlExportPlugin : IClientPlugin
    {
        public const string PluginName = "SpecLog.HtmlExportPlugin";

        public string Name
        {
            get { return PluginName; }
        }

        public string Description
        {
            get { return "Periodically generates an HTML export of the whole repository."; }
        }

        public bool IsConfigurable(RepositoryMode repositoryMode)
        {
            return repositoryMode == RepositoryMode.ClientServer;
        }

        public IDialogViewModel GetConfigDialog(RepositoryMode repositoryMode, bool isEnabled, string configuration)
        {
            return new HtmlExportPluginConfigDialogViewModel(configuration, isEnabled);
        }

        public bool IsGherkinLinkProvider(RepositoryMode repositoryMode)
        {
            return false;
        }

        public IGherkinLinkProviderViewModel GetGherkinLinkViewModel(RepositoryMode repositoryMode)
        {
            return null;
        }

        public bool IsGherkinStatsProvider(RepositoryMode repositoryMode)
        {
            return false;
        }

        public IGherkinStatsProvider CreateStatsProvider(RepositoryMode repositoryMode, string configuration, IGherkinStatsRepository statsRepository)
        {
            return null;
        }

        public bool IsWorkItemSynchronizer(RepositoryMode repositorMode)
        {
            return false;
        }

        public IEnumerable<PluginCommand> GetSupportedCommands(RepositoryMode repositoryMode)
        {
            return Enumerable.Empty<PluginCommand>();
        }
    }
}
