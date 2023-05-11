// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Aranda.Common.Agent.Updater.Versioning.Executable
{
    internal class ExecutableVersioning : IExecutableVersioning
    {
        private readonly ILogger _logger;

        public ExecutableVersioning(ILogger<ExecutableVersioning> logger)
        {
            _logger = logger;
        }

        public string? GetExecutableVersion(string executablePath)
        {
            try
            {
                FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(executablePath);
                return fileInfo.FileVersion ?? fileInfo.ProductVersion;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting executable file version {error}", ex.Message);
                throw;
            }
        }
    }
}