using System;
using System.Linq;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Notifications;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Interfaces.Services;
using Ubus.Business.Validations;

namespace Ubus.Business.Services
{
    public class RouteService : BaseService<Route>, IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly ITripRepository _tripRepository;

        public RouteService(IRouteRepository routeRepository, INotifier notifier, ITripRepository tripRepository) : base(routeRepository, notifier)
        {
            _routeRepository = routeRepository;
            _tripRepository = tripRepository;
        }

        public override async Task Add(Route route)
        {
            if (!ValidationExecute(new RouteValidation(), route)) return;

            await _routeRepository.Add(route);
        }

        public override async Task Remove(Guid id)
        {
            var trip = await _tripRepository.GetTripByRoutId(id);

            if (trip.Count() <= 0)
            {
                Notifier("Não foi possível excluir essa rota, pois há uma Viagem com a mesma.");
                return;
            }

            await _routeRepository.Remove(id);
        }

        public override async Task Update(Route route)
        {
            if (!ValidationExecute(new RouteValidation(), route)) return;

            await _routeRepository.Update(route);
        }

    }
}
