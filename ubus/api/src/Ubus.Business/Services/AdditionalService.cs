using System;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Interfaces.Services;

namespace Ubus.Business.Services
{
    public class AdditionalService : BaseService<Additional>, IAdditionalService
    {
        private readonly IAdditionalRepository _additionalRepository;

        public AdditionalService(IAdditionalRepository additionalRepository) : base(additionalRepository)
        {
            _additionalRepository = additionalRepository;
        }

        public override async Task Add(Additional additional)
        {
            await _additionalRepository.Add(additional);
        }

        public override async Task Remove(Guid id)
        {
            await _additionalRepository.Remove(id);
        }

        public override async Task Update(Additional additional)
        {
            await _additionalRepository.Update(additional);
        }

    }
}
