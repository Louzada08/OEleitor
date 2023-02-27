using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace OEleitor.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "OEleitor API",
                    Version = "v1"
                });
                c.CustomSchemaIds(i => i.FullName);
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Insira apenas o token, sem a palavra-chave 'Bearer'",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                });

                c.OperationFilter<AuthenticationRequirementsOperationFilter>();
            });
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo()
            //    {
            //        Title = "SEMUS OEleitor APIs",
            //        Description = "Esta API faz parte do sistema OEleitor.",
            //        Contact = new OpenApiContact() { Name = "Anderson Luiz Louzada", Email = "valuz.anderson.to@gmail.com" },
            //        License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            //    });

            //});

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //   //c.RoutePrefix = "api/eleitores";
            //    c.RoutePrefix = "api/bairros";
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            //    c.DocExpansion(DocExpansion.None);
            //});

            return app;
        }
    }
}
