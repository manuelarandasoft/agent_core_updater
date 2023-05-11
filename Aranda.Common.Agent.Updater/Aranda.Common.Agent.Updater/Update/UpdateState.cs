// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Common.Agent.Updater.Update
{
    /// <summary>
    /// Estados del actualizador
    /// </summary>
    public enum UpdateState
    {
        /// <summary>
        /// Estado inicial o actualizado
        /// </summary>
        Initial,

        /// <summary>
        /// Hay una nueva versión lista para descargarse
        /// </summary>
        WaitingToDownload,

        /// <summary>
        /// Ya hay un instalador descargado listo para ejecutarse
        /// </summary>
        ReadyToInstall
    }
}