// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Common.Agent.Updater.Update
{
    /// <summary>
    /// Se encarga de hacer la actualización. Funciona como fachada
    /// </summary>
    public interface IAgentUpdater
    {
        /// <summary>
        /// Busca actualizacione
        /// </summary>
        /// <returns></returns>
        Task<bool> ChekUpdates();

        /// <summary>
        /// Descarga la última versión obtenida. Debe llamarse luego de CheckUpdates
        /// </summary>
        /// <returns></returns>
        Task<bool> DownloadLastestVersion();

        /// <summary>
        /// Retorna el estado actual o la etapa en que se encuentra
        /// </summary>
        /// <returns></returns>
        UpdateState GetState();

        /// <summary>
        /// Ejecuta la actualización. Debe ser ejecutada después de haber descargado la última versión
        /// </summary>
        bool RunUpdate();
    }
}