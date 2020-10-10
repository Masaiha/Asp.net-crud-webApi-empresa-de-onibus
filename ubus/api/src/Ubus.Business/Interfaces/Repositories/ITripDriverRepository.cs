using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Entities;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface ITripDriverRepository : IBaseRepository<TripDriver>
    {
        Task<IEnumerable<TripDriver>> GetAllTripsDrivers();
        TripDriver GetByTripId(Guid id);
        TripDriver GetByDriverId(Guid id);
    }
}
