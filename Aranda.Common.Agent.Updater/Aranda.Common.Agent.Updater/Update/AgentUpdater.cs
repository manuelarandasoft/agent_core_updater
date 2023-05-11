// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Common.Agent.Updater.Download.Client;
using Aranda.Common.Agent.Updater.Installation.Execution;
using Aranda.Common.Agent.Updater.Options;
using Aranda.Common.Agent.Updater.Versioning.Client;
using Aranda.Common.Agent.Updater.Versioning.Comparator;
using Aranda.Common.Agent.Updater.Versioning.Executable;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Aranda.Common.Agent.Updater.Update
{
    internal class AgentUpdater : IAgentUpdater
    {
        private readonly IDownloadClient _downloadClient;
        private readonly IExecutableVersioning _executableVersioning;
        private readonly IInstallerExecutor _installerExecutor;
        private readonly ILogger _logger;
        private readonly UpdaterOptions _updaterOptions;
        private readonly IVersionClient _versionClient;
        private readonly IVersionComparator _versionComparator;
        private string _downloadPath;
        private string _lastestVersion;
        private UpdateState _updateState;

        public AgentUpdater(
            ILogger<AgentUpdater> logger,
            IDownloadClient downloadClient,
            IExecutableVersioning executableVersioning,
            IInstallerExecutor installerExecutor,
            IOptions<UpdaterOptions> updaterOptions,
            IVersionClient versionClient,
            IVersionComparator versionComparator)
        {
            _downloadClient = downloadClient;
            _executableVersioning = executableVersioning;
            _installerExecutor = installerExecutor;
            _logger = logger;
            _updaterOptions = updaterOptions.Value;
            _versionClient = versionClient;
            _versionComparator = versionComparator;
            _downloadPath = string.Empty;
            _lastestVersion = string.Empty;
            _updateState = UpdateState.Initial;
        }

        public async Task<bool> ChekUpdates()
        {
            bool result = false;
            _logger.LogDebug("Checking updates for software {software}", _updaterOptions.InstallerId);
            string lastestVersion = await _versionClient.GetLastAgentVersion();
            string? executableVersion = _executableVersioning.GetExecutableVersion(_updaterOptions.ProductExecutablePath);
            if (executableVersion == null)
            {
                _logger.LogError("Unable to get executable version {executable}", _updaterOptions.ProductExecutablePath);
            }
            else if (_versionComparator.Compare(lastestVersion, executableVersion) == ComparisonResult.GreaterThan)
            {
                _logger.LogInformation("Found new version {version} of software {software}", lastestVersion, _updaterOptions.InstallerId);
                _lastestVersion = lastestVersion;
                _updateState = UpdateState.WaitingToDownload;
                result = true;
            }
            return result;
        }

        public async Task<bool> DownloadLastestVersion()
        {
            bool result = false;
            if (!string.IsNullOrEmpty(_lastestVersion))
            {
                _downloadPath = await _downloadClient.Download(_lastestVersion);
                _lastestVersion = string.Empty;
                _updateState = UpdateState.ReadyToInstall;
                result = true;
            }
            return result;
        }

        public UpdateState GetState()
        {
            return _updateState;
        }

        public bool RunUpdate()
        {
            bool result = false;
            if (!string.IsNullOrEmpty(_downloadPath))
            {
                result = _installerExecutor.Install(_downloadPath);
                _updateState = UpdateState.Initial;
                _downloadPath = string.Empty;
            }
            return result;
        }
    }
}