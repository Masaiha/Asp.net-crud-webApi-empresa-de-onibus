using System;
using System.Threading.Tasks;
using Ubus.Business.Entities;

namespace Ubus.Business.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(Guid id);

    }
}
