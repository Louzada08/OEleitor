using AutoMapper;
using Backoffice.Infra.IOC.AutoMapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace OEleitor.Infra.IoC.IOC
{
    public static class AutoMapperInjector
    {
        public static IServiceCollection AddAutoMapperInjector(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EleitorProfile());
                mc.AddProfile(new BairroProfile());
                mc.AddProfile(new UserProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
