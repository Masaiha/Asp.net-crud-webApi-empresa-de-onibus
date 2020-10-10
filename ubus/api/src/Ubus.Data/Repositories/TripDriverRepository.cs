using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class TripDriverRepository : BaseRepository<TripDriver>, ITripDriverRepository
    {
        public TripDriverRepository(TripContext context) : base(context) { }

        public async Task<IEnumerable<TripDriver>> GetAllTripsDrivers()
        {
            return await Db.TripDrivers.AsNoTracking()
                    .Include(td => td.Drivers)
                    .Include(td => td.Trip)
                    .ToListAsync();
        }

        public TripDriver GetByDriverId(Guid id)
        {
            return Db.TripDrivers.AsNoTracking()
                     .FirstOrDefault(td => td.DriverId == id);
                      
        }

        public TripDriver GetByTripId(Guid id)
        {
            return Db.TripDrivers.AsNoTracking()
                    .FirstOrDefault(td => td.TripId == id);

        }
    }
}
