using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using TechTalk.SpecLog.Common;
using TechTalk.SpecLog.DataAccess;
using TechTalk.SpecLog.DataAccess.Repositories;
using TechTalk.SpecLog.GherkinParsing;
using TechTalk.SpecLog.HtmlExport;

namespace SpecLog.HtmlExportPlugin.Server
{
    public interface IHtmlExportPluginContainerSetup : IPluginContainerSetup
    {
        IUnityContainer CreateContainer(IHtmlExportPluginConfiguration configuration);
    }

    public class HtmlExportPluginContainerSetup : IHtmlExportPluginContainerSetup
    {
        IUnityContainer container;
        public virtual void Setup(IUnityContainer container)
        {
            this.container = container;
            container.RegisterInstance<IHtmlExportPluginContainerSetup>(this);
        }

        public IUnityContainer CreateContainer(IHtmlExportPluginConfiguration configuration)
        {
            var configuredContainer = container.CreateChildContainer();

            configuredContainer
                .RegisterInstance<IHtmlExportPluginConfiguration>(configuration)
                .RegisterType<IHtmlExportService, HtmlExportService>(new ContainerControlledLifetimeManager())
                .RegisterType<IRequirementRepository, RequirementRepository>(new ContainerControlledLifetimeManager())
                .RegisterType<IHtmlExportActivity, HtmlExportActivity>(new ContainerControlledLifetimeManager())
                .RegisterType<ICardTemplateProvider, CardTemplateProvider>(new ContainerControlledLifetimeManager())
                .RegisterType<IRepositoryLanguageProvider, RepositoryLanguageProvider>(new ContainerControlledLifetimeManager())
                .RegisterType<IGherkinParser, GherkinParser>(new ContainerControlledLifetimeManager())
                .RegisterType<IRequirementIdGenerator, RequirementIdGenerator>(new ContainerControlledLifetimeManager())
            ;

            return configuredContainer;
        }
    }
}

