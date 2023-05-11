// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Common.Agent.Updater.Versioning.Client
{
    /// <summary>
    /// Se encarga de obtener información de la versión
    /// </summary>
    internal interface IVersionClient
    {
        /// <summary>
        /// Obtiene la última versión disponible
        /// </summary>
        /// <returns></returns>
        Task<string> GetLastAgentVersion();
    }
}