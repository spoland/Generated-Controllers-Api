using GeneratedControllers.Conventions;
using GeneratedControllers.FeatureProviders;
using GeneratedControllers.Persistence;
using GeneratedControllers.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace GeneratedControllers
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opt =>
            {
                opt.Conventions.Add(new GeneratedRouteControllerModelConvention());
                opt.Conventions.Add(new GeneratedNameControllerModelConvention());
                opt.Conventions.Add(new ApiExplorerGroupPerVersionConvention());
            }
            ).ConfigureApplicationPartManager(pm =>
            {
                pm.FeatureProviders.Add(new GeneratedControllerApplicationFeatureProvider());
            });

            services.AddSwagger();
            services.AddSingleton(typeof(Storage<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SwaggerConfiguration swaggerConfiguration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                swaggerConfiguration.ApiVersions.ForEach(v => c.SwaggerEndpoint($"/swagger/{v}/swagger.json", v));
                c.RoutePrefix = "";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
