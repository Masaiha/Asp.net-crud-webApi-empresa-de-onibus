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
    public class DriverService : BaseService<Driver>, IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly ITripRepository _tripRepository;

        public DriverService(IDriverRepository driverRepository, INotifier notifier, ITripRepository tripRepository) : base(driverRepository, notifier)
        {
            _driverRepository = driverRepository;
            _tripRepository = tripRepository;
        }

        public override async Task Add(Driver driver)
        {
            if (!ValidationExecute(new DriverValidation(), driver)) return;

            await _driverRepository.Add(driver);
        }

        public override async Task Remove(Guid id)
        {
            var trip = await _tripRepository.GetTripByDriverId(id);

            if (trip.Count() <= 0)
            {
                Notifier("Não foi possível excluir esse motorista, pois há uma Viagem com o mesmo");
                return;
            }

            await _driverRepository.Remove(id);
        }

        public override async Task Update(Driver driver)
        {
            if (!ValidationExecute(new DriverValidation(), driver)) return;

            await _driverRepository.Update(driver);
        }

    }
}
