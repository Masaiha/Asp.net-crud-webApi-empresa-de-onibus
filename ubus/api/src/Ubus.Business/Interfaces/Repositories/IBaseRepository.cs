using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ubus.Business.Entities;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(Guid id);

        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        
        Task<int> SaveChanges();

    }
}
