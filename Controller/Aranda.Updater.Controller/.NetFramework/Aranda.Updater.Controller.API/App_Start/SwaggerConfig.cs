// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Updater.Controller.API.SwaggerObject.Filter;
using Swashbuckle.Application;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web.Http;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Aranda.ADM.Web.API
{
    /// <summary>
    /// Configura la documentacion del API - OpenApi
    /// </summary>
    public static class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger("docs/{apiVersion}/swagger", c =>
            {
                c.Schemes(new[] { "http", "https" });
                c.SchemaId(x => x.FullName);
                c.SingleApiVersion("v1", "Aranda ADM API " + GetApiWebVersion());
                c.PrettyPrint();
                c.ApiKey("X-Authorization")
                .Description("Bearer Authentication")
                .Name("X-Authorization")
                .In("header");
                c.IncludeXmlComments(GetXmlCommentsPath());
                c.DescribeAllEnumsAsStrings();
                c.DocumentFilter<CustomSwaggerFilter>();
            });
        }

        private static string GetApiWebVersion()
        {
            string version = ConfigurationManager.AppSettings["ApiVersion"];
            return version ?? string.Empty;
        }

        private static string GetXmlCommentsPath()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\bin\";
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            return Path.Combine(baseDirectory, commentsFileName);
        }
    }
}