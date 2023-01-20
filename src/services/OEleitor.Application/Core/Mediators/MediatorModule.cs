using Autofac;
using MediatR;
using OEleitor.Application.Core.Behaviors;
using OEleitor.Domain.Notification;
using System.Reflection;

namespace OEleitor.Application.Core.Mediators
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { return componentContext.TryResolve(t, out object o) ? o : null; };
            });

            builder.RegisterType<NotificationDomainHandler>()
               .As<INotificationHandler<NotificationDomain>>()
               .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidatorCommandBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
