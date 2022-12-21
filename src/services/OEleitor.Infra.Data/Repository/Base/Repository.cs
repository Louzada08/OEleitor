using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OEleitor.Domain.Entities;
using OEleitor.Domain.Interfaces;
using OEleitor.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OEleitor.Infra.Data.Repository.Base
{
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected readonly OEleitorDbContext _context;

        public Repository(OEleitorDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //public virtual void Add(TEntity entity)
        //{
        //    _context.Set<TEntity>().Add(entity);
        //}

        public virtual async Task AddAsync(TEntity tentity)
        {
            if (tentity is Entity entity)
            {
                entity.DataCadastro = DateTime.Now;
                entity.DataAlteracao = DateTime.Now;
            }

            await _context.Set<TEntity>().AddAsync(tentity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities is Entity entity)
            {
                entity.DataCadastro = DateTime.Now;
                entity.DataAlteracao = DateTime.Now;
            }
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            await Task.FromResult(_context.Set<TEntity>().Remove(entity));
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() =>
            {
                _context.Set<TEntity>().RemoveRange(entities);
            });
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();

            GC.SuppressFinalize(this);
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            var result = _context.Set<TEntity>().AsQueryable();

            if (include != null)
                result = include(result);

            return await result.AsQueryable().ToListAsync();
        }


        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var result = _context.Set<TEntity>().Where(predicate);

            if (include != null)
                result = include(result);

            return await result.AsQueryable().FirstOrDefaultAsync();
        }

        public TEntity GetById(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(long? id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var result = _context.Set<TEntity>().Where(predicate);

            if (include != null)
                result = include(result);

            return await result.AsQueryable().ToListAsync();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TEntity>().Update(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Task.FromResult(_context.Set<TEntity>().Update(entity));
        }

        //public async Task CommitAsync()
        //{
        //    await _context.SaveChangesAsync();
        //}
    }
}
