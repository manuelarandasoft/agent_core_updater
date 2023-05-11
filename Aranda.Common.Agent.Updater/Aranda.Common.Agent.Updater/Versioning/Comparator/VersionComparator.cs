// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

namespace Aranda.Common.Agent.Updater.Versioning.Comparator
{
    /// <summary>
    /// Implementa comparación de versiones
    /// </summary>
    internal class VersionComparator : IVersionComparator
    {
        public ComparisonResult Compare(string version1, string version2)
        {
            Version versionInfo1 = new(version1);
            Version versionInfo2 = new(version2);
            return (ComparisonResult)versionInfo1.CompareTo(versionInfo2);
        }
    }
}