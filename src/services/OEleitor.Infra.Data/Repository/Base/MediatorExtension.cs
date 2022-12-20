using MediatR;
using Microsoft.Extensions.Logging;
using OEleitor.Domain.Entities;
using OEleitor.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace OEleitor.Infra.Data.Repository.Base
{
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, OEleitorDbContext ctx, ILogger<UnitOfWork> logger)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            logger.LogTrace("DispatchDomainEventsAsync Domain Entities", domainEntities);

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            logger.LogTrace("DispatchDomainEventsAsync Domain Events", domainEvents);

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    logger.LogTrace("DispatchDomainEventsAsync Publish Domain Events", domainEvent);
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
