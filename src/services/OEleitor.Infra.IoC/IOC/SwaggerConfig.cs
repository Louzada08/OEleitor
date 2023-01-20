using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace OEleitor.Infra.IoC.IOC
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            var xmlComentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlComentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlComentsFile);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "OEleitor.Api",
                    Description = "SEMUS - API OLeitor",
                    Contact = new OpenApiContact { Name = "SEMUS", Url = new Uri("https://www.semus-palmas.gov.br/") }
                });

                c.IncludeXmlComments(xmlComentsFullPath, true);

            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api/eleitores";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}
