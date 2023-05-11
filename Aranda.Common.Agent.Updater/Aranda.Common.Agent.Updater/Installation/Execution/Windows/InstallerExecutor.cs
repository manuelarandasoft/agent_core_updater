// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Common.Agent.Updater.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Aranda.Common.Agent.Updater.Installation.Execution
{
    internal class InstallerExecutor : IInstallerExecutor
    {
        private readonly ILogger _logger;
        private readonly UpdaterOptions _updaterOptions;

        public InstallerExecutor(ILogger<InstallerExecutor> logger, IOptions<UpdaterOptions> updaterOptions)
        {
            _logger = logger;
            _updaterOptions = updaterOptions.Value;
        }

        public bool Install(string executablePath)
        {
            try
            {
                Process cmdProcess = new();
                cmdProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmdProcess.StartInfo.CreateNoWindow = true;
                cmdProcess.StartInfo.UseShellExecute = false;
                cmdProcess.StartInfo.RedirectStandardOutput = true;
                cmdProcess.StartInfo.RedirectStandardError = true;
                cmdProcess.StartInfo.FileName = executablePath.Replace('/', '\\');
                cmdProcess.StartInfo.Arguments = _updaterOptions.InstallerArguments;
                cmdProcess.EnableRaisingEvents = true;
                cmdProcess.Start();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error executing command {error}", ex.Message);
                return false;
            }
        }
    }
}