// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Updater.Controller.API.Common.Installer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Aranda.Updater.Controller.API.Controllers
{
    [Route("api/installer")]
    [ApiController]
    public class InstallerController : ControllerBase
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/octet-stream")]
        public ActionResult<Stream> Get([FromQuery] InstallerInfo query)
        {
            FileStream stream = new("AVS.Agent.Installer.9.2.1.2.exe", FileMode.Open, FileAccess.Read);
            return File(stream, "application/octet-stream", "AVS.Agent.Installer.9.2.1.2.exe");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("lastest")]
        [Produces("application/json")]
        public ActionResult<VersionInfo> GetInfo([FromQuery] SoftwareInfo query)
        {
            return Ok(new VersionInfo { Version = "9.17.2.1" });
        }
    }
}