// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Common.Agent.Updater.Download.Cleaning;
using Aranda.Common.Agent.Updater.Download.Client;
using Aranda.Common.Agent.Updater.Installation.Execution;
using Aranda.Common.Agent.Updater.Options;
using Aranda.Common.Agent.Updater.Update;
using Aranda.Common.Agent.Updater.Versioning.Client;
using Aranda.Common.Agent.Updater.Versioning.Comparator;
using Aranda.Common.Agent.Updater.Versioning.Executable;
using Microsoft.Extensions.DependencyInjection;

namespace Aranda.Common.Agent.Updater.DependencyInjection
{
    public static class AddUpdaterDependencyInjection //serviceCollectionExtension
    {
        public static IServiceCollection AddAgentUpdater(this IServiceCollection services, Action<UpdaterOptions> options)
        {
            services.Configure(options);

            services.AddSingleton<IAgentUpdater, AgentUpdater>();
            services.AddSingleton<IDownloadClient, DownloadClient>();
            services.AddSingleton<IDownloadsCleaner, DownloadsCleaner>();
            services.AddSingleton<IInstallerExecutor, InstallerExecutor>();
            services.AddSingleton<IVersionClient, VersionClient>();
            services.AddSingleton<IVersionComparator, VersionComparator>();
            services.AddSingleton<IExecutableVersioning, ExecutableVersioning>();

            return services;
        }
    }
}