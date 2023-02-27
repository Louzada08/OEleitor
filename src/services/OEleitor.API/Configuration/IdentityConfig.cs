using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OEleitor.Infra.Context;
using OEleitor.Infra.CrossCurtting.Identidade;
using OEleitor.Infra.Extensions;

namespace OEleitor.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OEleitorDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("OEleitorConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<OEleitorDbContext>()
                .AddDefaultTokenProviders();

            //services.AddDefaultIdentity<IdentityUser>(options =>
            //    options.SignIn.RequireConfirmedAccount = true)
            //    .AddRoles<IdentityRole>()
            //    .AddErrorDescriber<IdentityMensagensPortugues>()
            //    .AddEntityFrameworkStores<OEleitorDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddJwtConfiguration(configuration);

            return services;

        }
    }
}