using System;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Notifications;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Interfaces.Services;
using Ubus.Business.Validations;

namespace Ubus.Business.Services
{
    public class TripService : BaseService<Trip>, ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IBusRepository _busRepository;
        private readonly IRouteRepository _routeRepository;

        public TripService(ITripRepository tripRepository, 
                           IDriverRepository driverRepository, 
                           IBusRepository busRepository, 
                           IRouteRepository routeRepository, 
                           INotifier notifier) : base(tripRepository, notifier)
        {
            _tripRepository = tripRepository;
            _driverRepository = driverRepository;
            _busRepository = busRepository;
            _routeRepository = routeRepository;
        }

        public override async Task Add(Trip trip)
        {
            DependenciesValidation(trip);
            if (!ValidationExecute(new TripValidation(), trip)) return;

            await _tripRepository.Add(trip);
            return;
        }

        public override async Task Remove(Guid id)
        {
            var trip = _tripRepository.GetById(id);
            var driver = _driverRepository.GetById(trip.Result.Driver.Id);
            var bus = _driverRepository.GetById(trip.Result.Bus.Id);
            var route = _driverRepository.GetById(trip.Result.Route.Id);

            string msgError = "Ops! não foi possível excluir essa viagem, pois Há";

            if(driver != null) { Notifier($"{msgError} um morotista vinculado"); return; };
            if (bus != null) { Notifier($"{msgError} um ônibus vinculado"); return; };
            if (route != null) { Notifier($"{msgError} uma rota vinculada"); return; };

            await _tripRepository.Remove(id);
            return;
        }

        public override async Task Update(Trip trip)
        {
            DependenciesValidation(trip);
            if (!ValidationExecute(new TripValidation(), trip)) return;

            await _tripRepository.Update(trip);
        }

        private void DependenciesValidation(Trip trip)
        {
            var driver = _driverRepository.GetById(trip.Driver.Id);
            var bus = _busRepository.GetById(trip.Bus.Id);
            var route = _routeRepository.GetById(trip.Route.Id);
            string msgError = "Ops! Não foi possível adidionar uma nova viagem, confira os dados";

            if (driver == null) { Notifier($"{msgError} do motorista"); return; };
            if (bus == null) { Notifier($"{msgError}  do ônibus"); return; };
            if (route == null) { Notifier($"{msgError}  da rota"); return; };
            if (trip.EndDate <= trip.StartDate) { Notifier("A data de fechamento da viagem não pode ser menor ou igual à data de abertura"); return; };
            if (trip.Price < 0) { Notifier("O preço da viagem não pode ser negativo"); return; };
        }
    }
}
