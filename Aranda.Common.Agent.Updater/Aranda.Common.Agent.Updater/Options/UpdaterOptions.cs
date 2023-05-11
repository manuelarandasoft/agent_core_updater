// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.ComponentModel.DataAnnotations;

namespace Aranda.Common.Agent.Updater.Options
{
    /// <summary>
    /// Configuraciones para el actualizador de agentes
    /// </summary>
    public sealed class UpdaterOptions
    {
        /// <summary>
        /// Dirección o ip del servidor
        /// </summary>
        [Required]
        [Url]
        public string ApiUrl { get; set; }

        /// <summary>
        /// Ruta donde se almacenan las descargas
        /// </summary>
        public string DownloadFolder { get; set; }

        /// <summary>
        /// Argumentos para ejecutar el instalador
        /// </summary>

        /// <summary>
        /// Indica cuánto tiempo se van a mantener las descargas antes de ser borradas
        /// </summary>
        [Required]
        public TimeSpan DownloadsRetentionTime { get; set; }

        [Required]
        public string InstallerArguments { get; set; }

        /// <summary>
        /// Llave del producto de Aranda en la forma Aranda.[[Product]].[[Sistema operativo]].[[Arquitectura]]
        /// </summary>
        [Required]
        public string InstallerId { get; set; }

        /// <summary>
        /// La ruta del ejecutable del producto
        /// </summary>
        [Required]
        public string ProductExecutablePath { get; set; }
    }
}