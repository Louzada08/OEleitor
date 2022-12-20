using MediatR;
using Microsoft.Extensions.Logging;
using OEleitor.Domain.Interfaces;
using OEleitor.Infra.Data.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OEleitor.Infra.Data.Repository.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly OEleitorDbContext _context;
        private readonly IMediator _mediator;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(OEleitorDbContext context, IMediator mediator, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                await _mediator.DispatchDomainEventsAsync(_context, _logger);

                var result = await _context.SaveChangesAsync();
                _logger.LogTrace("Is CommitAsync DataBase Results", result);
            }
            catch (Exception ex)
            {
                _logger.LogTrace("Error CommitAsync DataBase", ex);
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
