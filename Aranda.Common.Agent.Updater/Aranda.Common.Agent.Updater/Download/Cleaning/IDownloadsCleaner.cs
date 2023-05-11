// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Common.Agent.Updater.Download.Cleaning
{
    /// <summary>
    /// Se encarga de la limpieza de descargas
    /// </summary>
    public interface IDownloadsCleaner
    {
        /// <summary>
        /// Elimina archivo descargados por antigüedad
        /// </summary>
        void CleanOldDownloads();
    }
}