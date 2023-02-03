using Backoffice.Core.Services.PurchaseForms;
using Microsoft.Extensions.DependencyInjection;
using OEleitor.Domain.Interfaces.Services;

namespace OEleitor.Infra.IoC.IOC
{
    public static class ServicesInjector
    {
        public static IServiceCollection AddServicesInjector(this IServiceCollection services)
        {
            services.AddScoped<IEleitorService, EleitorService>();
            services.AddScoped<IBairroService, BairroService>();

            return services;
        }
    }
}
