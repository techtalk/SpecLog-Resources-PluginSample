using System;
using System.IO;
using TechTalk.SpecLog.Common;
using TechTalk.SpecLog.DataAccess.Boundaries;
using TechTalk.SpecLog.DataAccess.Repositories;
using TechTalk.SpecLog.Entities;
using TechTalk.SpecLog.HtmlExport;
using TechTalk.SpecLog.Logging;

namespace SpecLog.HtmlExportPlugin.Server
{
    public interface IHtmlExportActivity : IPeriodicActivity { }

    public class HtmlExportActivity : PeriodicActivity, IHtmlExportActivity
    {
        private readonly IHtmlExportService htmlExportService;
        private readonly IRequirementRepository requirementRepository;
        private readonly IRepositoryStorage repositoryStorage;
        private readonly IBoundary boundary;
        private readonly string outputPath;
        public HtmlExportActivity
        (
            ITimeService timeService, IHtmlExportPluginConfiguration htmlExportPluginConfiguration,
            IHtmlExportService htmlExportService, IRequirementRepository requirementRepository, IRepositoryStorage repositoryStorage, IBoundary boundary
        )
            : base(timeService, htmlExportPluginConfiguration)
        {
            this.htmlExportService = htmlExportService;
            this.requirementRepository = requirementRepository;
            this.repositoryStorage = repositoryStorage;
            this.boundary = boundary;
            outputPath = htmlExportPluginConfiguration.OutputPath;
        }

        protected override bool TriggerAction()
        {
            try
            {
                var repositoryName = repositoryStorage.GetRepository(boundary).Name;
                var fileName = Path.Combine(outputPath, String.Format("{0}.html", repositoryName));
                Logger.TechLog.Log(System.Diagnostics.TraceEventType.Information, "Exporting repository '{0}' to HTML...", repositoryName);
                htmlExportService.Export(requirementRepository.LoadAll(boundary), true, fileName);
                return true;
            }
            catch (Exception ex)
            {
                Logger.TechLog.Log(System.Diagnostics.TraceEventType.Error, "An exception has occurred during HTML export: '{0}'", ex.Message);
                return false;
            }
        }
    }
}
