// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Common.Agent.Updater.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace Aranda.Common.Agent.Updater.Download.Client
{
    internal class DownloadClient : IDownloadClient
    {
        private static readonly string API_PATH = "api/installer";
        private readonly ILogger _logger;
        private readonly UpdaterOptions _updaterOptions;

        public DownloadClient(ILogger<DownloadClient> logger, IOptions<UpdaterOptions> options)
        {
            _logger = logger;
            _updaterOptions = options.Value;
        }

        public async Task<string> Download(string version)
        {
            try
            {
                CreateDownloadFolder();
                string request = $"{_updaterOptions.ApiUrl}/{API_PATH}?softwareKey={_updaterOptions.InstallerId}&version={version}";
                _logger.LogDebug("About to send GET request: {request}", request);
                Uri uri = new(request);
                using HttpClient client = new();
                var response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                string fileName = GetFileName(response.Headers, version);

                string path = $"{_updaterOptions.DownloadFolder}/{fileName}";
                using FileStream fs = new(path, FileMode.Create);
                await response.Content.CopyToAsync(fs);
                return path;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error {error} sending GET request for download", ex.Message);
                throw;
            }
        }

        private void CreateDownloadFolder()
        {
            if (!Directory.Exists(_updaterOptions.DownloadFolder))
            {
                Directory.CreateDirectory(_updaterOptions.DownloadFolder);
            }
        }

        private string GetFileName(HttpResponseHeaders headers, string version)
        {
            if (headers.TryGetValues("content-disposition", out IEnumerable<string>? values) && values != null)
            {
                return new ContentDisposition(values.First()).FileName;
            }
            else
            {
                return $"{_updaterOptions.InstallerId}.{version}";
            }
        }
    }
}