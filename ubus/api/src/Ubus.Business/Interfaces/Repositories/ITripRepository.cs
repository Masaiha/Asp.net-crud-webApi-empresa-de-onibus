using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Entities;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface ITripRepository : IBaseRepository<Trip>
    {
        Task<IEnumerable<Trip>> GetAllTrips();
        Task<Trip> GetByIdWithRouteDriverBus(Guid id);
        Task<IEnumerable<Trip>> GetTripByRoutId(Guid id);
        Task<IEnumerable<Trip>> GetTripByDriverId(Guid id);
        Task<IEnumerable<Trip>> GetTripByBusId(Guid id);
    }
}
