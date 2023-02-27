using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OEleitor.Infra.Context;

namespace OEleitor.Infra.Data.Configuration
{
    public static class DbInitialization
    {
        public static async Task EnsureMigrationsApplied(this IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<OEleitorDbContext>();
                await context.Database.MigrateAsync();

            }
        }
    }
}
