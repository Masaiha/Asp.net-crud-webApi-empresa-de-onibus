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
    public class BusService : BaseService<Bus>, IBusService
    {
        private readonly IBusRepository _busRepository;
        private readonly ITripRepository _tripRepository;

        public BusService(IBusRepository busRepository, INotifier notifier, ITripRepository tripRepository) : base(busRepository, notifier)
        {
            _busRepository = busRepository;
            _tripRepository = tripRepository;
        }

        public override async Task Add(Bus bus)
        {
            if (!ValidationExecute(new BusValidation(), bus)) return;

            await _busRepository.Add(bus);
        }

        public override async Task Remove(Guid id)
        {
            var trip = await _tripRepository.GetTripByBusId(id);

            if (trip.Count() <= 0)
            {
                Notifier("Não foi possível excluir esse ônibus, pois há uma Viagem com a mesmo.");
                return;
            }

            await _busRepository.Remove(id);
        }

        public override async Task Update(Bus bus)
        {
            if (!ValidationExecute(new BusValidation(), bus)) return;

            await _busRepository.Update(bus);
        }

    }
}
