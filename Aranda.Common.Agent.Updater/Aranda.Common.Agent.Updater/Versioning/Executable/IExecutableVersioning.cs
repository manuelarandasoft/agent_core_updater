// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Common.Agent.Updater.Versioning.Executable
{
    internal interface IExecutableVersioning
    {
        /// <summary>
        /// Obtiene la información de la versión del ejecutable
        /// </summary>
        /// <param name="executablePath">Ruta del ejecutable</param>
        /// <returns></returns>
        string? GetExecutableVersion(string executablePath);
    }
}