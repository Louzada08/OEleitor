using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OEleitor.Infra.Context;
using OEleitor.Infra.CrossCurtting.Data;
using OEleitor.Infra.CrossCurtting.DomainObjects;
using System.Linq.Expressions;

namespace OEleitor.Infra.Repository.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
    {
        protected readonly OEleitorDbContext _context;
        public IUnitOfWork UnitOfWork { get; set; }
        protected readonly DbSet<TEntity> DbSet;
        private readonly IMapper _mapper;

        public BaseRepository(OEleitorDbContext context, IMapper mapper)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
            this.UnitOfWork = _context as IUnitOfWork;
            _mapper = mapper;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities is BaseEntity baseEntity)
            {
                baseEntity.DataCadastro = DateTime.UtcNow;
                baseEntity.DataAlteracao = DateTime.UtcNow;
            }

            await DbSet.AddRangeAsync(entities);
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.DataExclusao = DateTime.UtcNow;
                DbSet.Update(entity);
            }
            else
            {
                DbSet.Remove(entity);
            }

            await Task.FromResult(DbSet.Remove(entity));
            return entity;
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities is BaseEntity baseEntity)
            {
                baseEntity.DataExclusao = DateTime.UtcNow;
                DbSet.UpdateRange(entities);
            }
            else
            {
                DbSet.RemoveRange(entities);
            }

            await Task.Run(() =>
            {
                DbSet.RemoveRange(entities);
            });

        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            var result = DbSet.AsQueryable();

            if (include != null)
                result = include(result);

            return await result.AsQueryable().ToListAsync();
        }


        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await DbSet.Where(predicate).FirstOrDefaultAsync(predicate);

            return result;

        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var result = DbSet.Where(predicate);

            if (include != null)
                result = include(result);

            return await result.AsQueryable().FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(Guid? id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var result = DbSet.Where(predicate);

            if (include != null)
                result = include(result);

            return await result.AsQueryable().ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Task.FromResult(DbSet.Update(entity));
            return entity;
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();

            GC.SuppressFinalize(this);
        }

    }
}
