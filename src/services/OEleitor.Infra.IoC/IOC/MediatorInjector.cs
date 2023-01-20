using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OEleitor.Domain.Mediator;
using OEleitor.Domain.Mediator.Interfaces;

namespace OEleitor.Infra.IoC.IOC
{
    public static class MediatorInjector
    {
        public static IServiceCollection AddMediatorInjector(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //services.AddScoped<IRequestHandler<CreateUserRequest, ValidationResultBag>, UserCommandHandler>();
            //services.AddScoped<IRequestHandler<UpdateUserRequest, ValidationResultBag>, UserCommandHandler>();
            //services.AddScoped<IRequestHandler<PatchUserRequest, ValidationResultBag>, UserCommandHandler>();
            //services.AddScoped<IRequestHandler<DeleteUserRequest, ValidationResultBag>, UserCommandHandler>();

            return services;
        }
    }
}
