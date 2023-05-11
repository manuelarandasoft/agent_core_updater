// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

namespace Aranda.Common.Agent.Updater.Versioning.Comparator
{
    /// <summary>
    /// Se encarga de comparar dos versiones
    /// </summary>
    internal interface IVersionComparator
    {
        /// <summary>
        /// Compara dos versiones
        /// </summary>
        /// <param name="version1">Primera versión</param>
        /// <param name="version2">Segunda versión</param>
        /// <returns>Resultado</returns>
        ComparisonResult Compare(string version1, string version2);
    }
}