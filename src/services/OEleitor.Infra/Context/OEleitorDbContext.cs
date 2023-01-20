using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Interfaces;
using OEleitor.Domain.Interfaces.Base;
using OEleitor.Domain.Mediator.Interfaces;
using OEleitor.Domain.Messages;
using OEleitor.Infra.EntitiesConfiguration;
using OEleitor.Infra.Extensions;
using System.Data.Common;

namespace OEleitor.Infra.Context
{
    public class OEleitorDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;
        public OEleitorDbContext(DbContextOptions<OEleitorDbContext> options, 
                                IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Eleitor> Eleitores { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Bairro> Bairros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            base.OnModelCreating(modelBuilder);

            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IBaseEntity).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                    property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new EleitorConfiguration());
            modelBuilder.ApplyConfiguration(new DependenteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new BairroConfiguration());
        }

        public bool DatabaseExists()
        {
            try
            {
                return Database.GetService<IRelationalDatabaseCreator>().Exists();
            }
            catch (DbException)
            {
                return false;
            }
        }

        public async Task<bool> Commit()
        {
            if (await base.SaveChangesAsync() <= 0)
                return false;

            await _mediatorHandler.PublishEvents(this);

            return true;
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
