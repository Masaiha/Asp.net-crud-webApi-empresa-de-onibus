using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class TripRepository : BaseRepository<Trip>, ITripRepository
    {
        public TripRepository(TripContext context) : base(context) { }

        public async Task<IEnumerable<Trip>> GetAllTrips()
        {
            return await Db.Trips.AsNoTracking()
                    .Include(t => t.Bus)
                    .Include(t => t.Driver)
                    .Include(t => t.Route)
                    .ToListAsync();
        }

        public async Task<Trip> GetByIdWithRouteDriverBus()
        {

        }
    }
}
