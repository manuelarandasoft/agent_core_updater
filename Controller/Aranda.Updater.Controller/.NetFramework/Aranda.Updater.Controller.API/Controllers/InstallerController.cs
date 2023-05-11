// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Updater.Controller.API.Common.Installer.Entities;
using System.IO;
using System.Web.Http;

namespace Aranda.Updater.Controller.API.Controllers
{
    public class InstallerController : ApiController
    {
        public Stream Get([FromUri] InstallerInfo query)
        {
            using (FileStream stream = new FileStream("installer.exe", FileMode.Open, FileAccess.Read))
            {
                return stream;
            }
        }

        public VersionInfo GetInfo([FromUri] SoftwareInfo query)
        {
            return new VersionInfo();
        }
    }
}