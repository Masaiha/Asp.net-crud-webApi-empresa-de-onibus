using System;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Interfaces.Services;

namespace Ubus.Business.Services
{
    public class TripService : BaseService<Trip>, ITripService
    {
        private readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository) : base(tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public override async Task Add(Trip trip)
        {
            await _tripRepository.Add(trip);
        }

        public override async Task Remove(Guid id)
        {
            await _tripRepository.Remove(id);
        }

        public override async Task Update(Trip trip)
        {
            await _tripRepository.Update(trip);
        }
    }
}
