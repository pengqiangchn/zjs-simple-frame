using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zjs.Module.DataContext;
using zjs.SeedWork;

namespace zjs.Module.Repositorys
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly MyContext _context;

        public Repository(MyContext myContext)
        {
            if (myContext == null)
                throw new ArgumentNullException("MyContext");

            _context = myContext;
        }

        public virtual void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            _context.Add(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            //    _context.Entry<TEntity>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            _context.Remove(entity);
        }

        public virtual void Remove(IEnumerable<TEntity> entities)
        {
            _context.Remove(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            _context.Update(entities);
        }

        public virtual void Attach(TEntity entity)
        {
            _context.Attach(entity);
        }

        public virtual void Attach(IEnumerable<TEntity> entities)
        {
            _context.Attach(entities);
        }

        public virtual TEntity Get(object id)
        {
            return _context.Find<TEntity>(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().Where(filter);
        }

        public virtual async Task<TEntity> GetAsync(object id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetFilteredAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        void IDisposable.Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

    }
}
