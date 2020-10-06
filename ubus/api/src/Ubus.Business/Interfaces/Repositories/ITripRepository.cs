using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Entities;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface ITripRepository : IBaseRepository<Trip>
    {
        Task<IEnumerable<Trip>> GetAllTrips();
    }
}
