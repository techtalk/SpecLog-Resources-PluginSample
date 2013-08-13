using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecLog.Application.Common.PluginsInfrastructure;

namespace SpecLog.HtmlExportPlugin.Client
{
    public class HtmlExportPluginConfigDialogViewModel : PluginConfigurationDialogViewModel<HtmlExportPluginConfiguration>
    {
        public HtmlExportPluginConfigDialogViewModel(string config, bool enabled) : base(config, enabled) { }

        public override string Caption
        {
            get { return "HTML Export Plugin Configuration"; }
        }

        public string OutputPath
        {
            get { return configuration.OutputPath; }
            set
            {
                configuration.OutputPath = Trim(value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public int GenerationIntervalMinutes
        {
            get { return configuration.GenerationIntervalMinutes; }
            set
            {
                configuration.GenerationIntervalMinutes = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public override bool CanSave()
        {
            return IsEnabled == false
                || (!string.IsNullOrWhiteSpace(OutputPath)
                && GenerationIntervalMinutes > 0);
        }
    }
}
