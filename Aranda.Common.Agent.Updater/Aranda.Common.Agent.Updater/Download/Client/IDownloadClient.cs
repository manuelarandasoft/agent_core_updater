// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Common.Agent.Updater.Download.Client
{
    /// <summary>
    /// Se encarga de descargar el archivo solicitado
    /// </summary>
    internal interface IDownloadClient
    {
        /// <summary>
        /// Descarga el archivo dado a la carpeta especificada
        /// </summary>
        /// <param name="version">Versión del archivo a descargar</param>
        /// <returns>Ruta donde descargó el paquete</returns>
        Task<string> Download(string version);
    }
}