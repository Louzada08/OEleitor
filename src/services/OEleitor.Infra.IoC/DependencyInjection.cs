using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OEleitor.Domain.Interfaces;
using OEleitor.Infra.Data.Context;
using OEleitor.Infra.Data.Repository;

namespace OEleitor.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<OEleitorDbContext>(options =>
             options.UseNpgsql(configuration.GetConnectionString("OEleitorDatabase"
            ), b => b.MigrationsAssembly(typeof(OEleitorDbContext).Assembly.FullName)));

            services.AddScoped<IEleitorRepository, EleitorRepository>();
            services.AddScoped<IBairroRepository, BairroRepository>();

            return services;
        }
    }
}
