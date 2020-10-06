using System;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Interfaces.Services;

namespace Ubus.Business.Services
{
    public class BusService : BaseService<Bus>, IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository) : base(busRepository)
        {
            _busRepository = busRepository;
        }

        public override async Task Add(Bus bus)
        {
            await _busRepository.Add(bus);
        }

        public override async Task Remove(Guid id)
        {
            await _busRepository.Remove(id);
        }

        public override async Task Update(Bus bus)
        {
            await _busRepository.Update(bus);
        }

    }
}
