// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Common.Agent.Updater.CLI.Workers;
using Aranda.Common.Agent.Updater.DependencyInjection;
using System.Runtime.InteropServices;

string osName = string.Empty;
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    osName = "Windows";
}
else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    osName = "Linux";
}
else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
{
    osName = "OSX";
}

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddAgentUpdater(options =>
        {
            options.ApiUrl = "https://localhost:7292";
            options.InstallerId = $"Aranda.AVS.Agent.{osName}.x64";
            options.ProductExecutablePath = "Aranda.AVS.Agent.Windows.ServiceLocalSystem.exe";
            options.InstallerArguments = @"/S /V""/norestart /qn""";
            options.DownloadFolder = ".\\Downloads";
            options.DownloadsRetentionTime = TimeSpan.FromMinutes(2);
        });
        services.AddHostedService<UpdaterWorker>();
    })
    .Build();

await host.RunAsync();