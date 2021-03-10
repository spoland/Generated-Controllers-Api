using GeneratedControllers.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GeneratedControllers.Swagger
{
    /// <summary>
    /// Swagger related service collection extension methods
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        private readonly static string ApiDescription = "Generated Controller API POC";

        /// <summary>
        /// Adds the swagger.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var asm = Assembly.GetExecutingAssembly();
            var apiVersions = asm.GetTypes()
                .Where(type => type.GetCustomAttributes().Select(x => x.GetType().Name).Contains(nameof(GeneratedControllerAttribute)))
                .SelectMany(x => x.GetCustomAttributes())
                .OfType<GeneratedControllerAttribute>()
                .Select(x =>
                {
                    var version = x.ApiVersion;
                    return $"{version.MajorVersion}.{version.MinorVersion}";
                })
                .Distinct()
                .ToList();

            services.AddSwaggerGen(c =>
            {
                c.DocumentFilter<HideGeneratedControllerDocumentFilter>();

                apiVersions.ForEach(v => c.SwaggerDoc(v, new OpenApiInfo
                {
                    Title = "Generated Controller API",
                    Description = ApiDescription,
                    Version = v
                }));

                var filePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

                c.IncludeXmlComments(filePath, includeControllerXmlComments: true);
            });

            var swaggerConfig = new SwaggerConfiguration(apiVersions);

            services.AddSingleton(swaggerConfig);

            return services;
        }
    }
}
