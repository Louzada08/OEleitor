using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OEleitor.Application.Commands.EleitorModelo.Handlers;
using OEleitor.Application.Commands.EleitorModelo.Requests;
using OEleitor.Domain.Mediator;
using OEleitor.Domain.Mediator.Interfaces;
using OEleitor.Infra.CrossCurtting.Validation;

namespace OEleitor.Infra.IoC.IOC
{
    public static class MediatorInjector
    {
        public static IServiceCollection AddMediatorInjector(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<AdicionarEleitorCommand, ValidationResultBag>, EleitorCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarBairroCommand, ValidationResultBag>, BairroCommandHandler>();

            //services.AddScoped<IRequestHandler<UpdateUserRequest, ValidationResultBag>, UserCommandHandler>();
            //services.AddScoped<IRequestHandler<PatchUserRequest, ValidationResultBag>, UserCommandHandler>();
            //services.AddScoped<IRequestHandler<DeleteUserRequest, ValidationResultBag>, UserCommandHandler>();

            return services;
        }
    }
}
