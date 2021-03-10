using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace GeneratedControllers.Swagger
{
    public class HideGeneratedControllerDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var pathsToRemove = swaggerDoc.Paths.Where(x => x.Key.Contains("generated")).ToList();
            pathsToRemove.ForEach(path => swaggerDoc.Paths.Remove(path.Key));
        }
    }
}
