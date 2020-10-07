using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Entities;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface IBusRepository : IBaseRepository<Bus>
    {
        Task<IEnumerable<Bus>> GetAllBusAdditionals();

        Task<IEnumerable<Bus>> GetBusByAdditionalId(Guid id);
    }
}
