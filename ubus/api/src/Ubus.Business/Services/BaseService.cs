using System;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Interfaces.Services;

namespace Ubus.Business.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task Add(TEntity entity)
        {
            await _repository.Add(entity);
        }

        public virtual async Task Remove(Guid id)
        {
            await _repository.Remove(id);
        }

        public virtual async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
