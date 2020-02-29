using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace zjs.SeedWork
{
    public interface IRepository<TEntity> : IDisposable
           where TEntity : Entity
    {
        void Add(TEntity entity);

        void Add(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void Remove(IEnumerable<TEntity> entities);

        void Attach(TEntity entity);

        void Attach(IEnumerable<TEntity> entities);

        TEntity Get(object id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetAsync(object id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetFilteredAsync(Expression<Func<TEntity, bool>> filter);

    }
}
