// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ADM.Web.API;
using System.Web.Http;

namespace Aranda.Updater.Controller.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            SwaggerConfig.Register(config);
        }
    }
}