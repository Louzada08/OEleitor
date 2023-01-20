﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OEleitor.Domain.Interfaces;
using OEleitor.Infra.Context;
using OEleitor.Infra.Repository;

namespace OEleitor.Infra.IoC.IOC
{
    public static class DbInjector
    {
        public static IServiceCollection AddDbInjector(this IServiceCollection services)
        {
            services.AddScoped<OEleitorDbContext>();
            services.AddScoped<IEleitorRepository, EleitorRepository>();
            services.AddScoped<IBairroRepository, BairroRepository>();

            return services;
        }

        public static IServiceCollection AddDbContextInjector(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OEleitorDbContext>(options => options.UseNpgsql(connectionString));
            return services;
        }
    }
}
