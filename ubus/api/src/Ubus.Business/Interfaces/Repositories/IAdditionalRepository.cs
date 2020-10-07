using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Entities;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface IAdditionalRepository : IBaseRepository<Additional>
    {
        Task<IEnumerable<Additional>> GetAllAdditionalsBus();
        Task<Additional> GetByIddditionalsBus(Guid id);
    }
}
