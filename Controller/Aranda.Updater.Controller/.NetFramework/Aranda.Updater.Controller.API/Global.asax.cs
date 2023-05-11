// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Web.Http;

namespace Aranda.Updater.Controller.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}