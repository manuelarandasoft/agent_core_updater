// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Common.Agent.Updater.Download.Cleaning;
using Aranda.Common.Agent.Updater.Update;

namespace Aranda.Common.Agent.Updater.CLI.Workers
{
    internal class UpdaterWorker : BackgroundService
    {
        private readonly IDownloadsCleaner _cleaner;
        private readonly ILogger _logger;
        private readonly IAgentUpdater _updater;

        public UpdaterWorker(ILogger<UpdaterWorker> logger, IAgentUpdater updater, IDownloadsCleaner cleaner)
        {
            _logger = logger;
            _updater = updater;
            _cleaner = cleaner;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                if (await _updater.ChekUpdates() && await _updater.DownloadLastestVersion())
                {
                    _updater.RunUpdate();
                }
                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);
                    _cleaner.CleanOldDownloads();
                }
            }
            catch (Exception ex) when (stoppingToken.IsCancellationRequested)
            {
                _logger.LogError("Cancelled updates Error {error}", ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unkown error {error}", ex.Message);
            }
        }
    }
}