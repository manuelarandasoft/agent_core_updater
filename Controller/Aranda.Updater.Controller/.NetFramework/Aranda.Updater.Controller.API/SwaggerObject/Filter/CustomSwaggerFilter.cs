// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Swashbuckle.Swagger;
using System.Linq;
using System.Web.Http.Description;

namespace Aranda.Updater.Controller.API.SwaggerObject.Filter
{
    public class CustomSwaggerFilter : IDocumentFilter
    {
        /// <summary>
        /// Eliminar contenido del controller de la common de swagger
        /// </summary>
        /// <param name="swaggerDoc">Documento de swagger</param>
        /// <param name="schemaRegistry">Esquema de registo</param>
        /// <param name="apiExplorer">Explorador de la api</param>
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            var nonMobileRoutes = swaggerDoc.paths
               .Where(x => x.Key.ToLower().Contains("api/externalauth"))
               .ToList();
            nonMobileRoutes.ForEach(x => { swaggerDoc.paths.Remove(x.Key); });
        }
    }
}