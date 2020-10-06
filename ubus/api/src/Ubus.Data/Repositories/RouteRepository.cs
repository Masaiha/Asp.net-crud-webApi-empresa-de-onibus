using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(TripContext context) : base(context) { }
    }
}
