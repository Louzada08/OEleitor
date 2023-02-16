using Backoffice.Core.Services.PurchaseForms;
using Microsoft.Extensions.DependencyInjection;
using OEleitor.Application.Query;
using OEleitor.Application.Query.Interface;
using OEleitor.Domain.Interfaces.Services;

namespace OEleitor.Infra.IoC.IOC
{
    public static class ServicesInjector
    {
        public static IServiceCollection AddServicesInjector(this IServiceCollection services)
        {
            services.AddScoped<IEleitorService, EleitorService>();
            services.AddScoped<IEleitorQuery, EleitorQuery>();
            services.AddScoped<IBairroService, BairroService>();
            services.AddScoped<IBairroQuery, BairroQuery>();

            return services;
        }
    }
}
