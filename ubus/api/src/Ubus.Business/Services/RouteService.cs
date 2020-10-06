using System;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Interfaces.Services;

namespace Ubus.Business.Services
{
    public class RouteService : BaseService<Route>, IRouteService
    {
        private readonly IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRepository) : base(routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public override async Task Add(Route route)
        {
            await _routeRepository.Add(route);
        }

        public override async Task Remove(Guid id)
        {
            await _routeRepository.Remove(id);
        }

        public override async Task Update(Route route)
        {
            await _routeRepository.Update(route);
        }

    }
}
