// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Common.Agent.Updater.Installation.Execution
{
    /// <summary>
    /// Ejecuta el instalaor independiende de la plataforma
    /// </summary>
    internal interface IInstallerExecutor
    {
        /// <summary>
        /// Ejecuta el instalador
        /// </summary>
        /// <param name="executablePath">Ruta al instalador</param>
        bool Install(string executablePath);
    }
}