using System;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Interfaces.Services;

namespace Ubus.Business.Services
{
    public class DriverService : BaseService<Driver>, IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository) : base(driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public override async Task Add(Driver driver)
        {
            await _driverRepository.Add(driver);
        }

        public override async Task Remove(Guid id)
        {
            await _driverRepository.Remove(id);
        }

        public override async Task Update(Driver driver)
        {
            await _driverRepository.Update(driver);
        }

    }
}
