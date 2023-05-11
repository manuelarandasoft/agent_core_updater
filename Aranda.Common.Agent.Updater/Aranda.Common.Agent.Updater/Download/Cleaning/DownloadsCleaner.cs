// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Common.Agent.Updater.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Aranda.Common.Agent.Updater.Download.Cleaning
{
    internal class DownloadsCleaner : IDownloadsCleaner
    {
        private readonly ILogger _logger;
        private readonly UpdaterOptions _updaterOptions;

        public DownloadsCleaner(ILogger<DownloadsCleaner> logger, IOptions<UpdaterOptions> options)
        {
            _logger = logger;
            _updaterOptions = options.Value;
        }

        public void CleanOldDownloads()
        {
            DateTime oldestTime = DateTime.Now - _updaterOptions.DownloadsRetentionTime;
            foreach (string file in Directory.EnumerateFiles(_updaterOptions.DownloadFolder))
            {
                FileInfo fileInfo = new(file);
                if (fileInfo.LastAccessTime <= oldestTime)
                {
                    _logger.LogInformation("About to delete downloaded file {file}", file);
                    File.Delete(file);
                }
            }
        }
    }
}