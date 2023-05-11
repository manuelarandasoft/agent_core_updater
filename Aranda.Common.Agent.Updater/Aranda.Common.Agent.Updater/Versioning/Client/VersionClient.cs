// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Common.Agent.Updater.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Aranda.Common.Agent.Updater.Versioning.Client
{
    internal class VersionClient : IVersionClient
    {
        private static readonly string API_PATH = "api/installer/lastest";
        private readonly ILogger _logger;
        private readonly UpdaterOptions _updaterOptions;

        public VersionClient(ILogger<VersionClient> logger, IOptions<UpdaterOptions> options)
        {
            _logger = logger;
            _updaterOptions = options.Value;
        }

        public async Task<string> GetLastAgentVersion()
        {
            try
            {
                string request = $"{_updaterOptions.ApiUrl}/{API_PATH}?softwareKey={_updaterOptions.InstallerId}";
                _logger.LogDebug("About to send GET request {request}", request);
                using HttpClient client = new();
                client.Timeout = TimeSpan.FromMinutes(1);
                var result = await client.GetAsync(request);
                result.EnsureSuccessStatusCode();
                VersionInfo? version = await result.Content.ReadFromJsonAsync<VersionInfo>();
                if (version == null)
                {
                    return string.Empty;
                }
                return version.Version;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error {error} sending GET request to get version", ex.Message);
                throw;
            }
        }
    }
}