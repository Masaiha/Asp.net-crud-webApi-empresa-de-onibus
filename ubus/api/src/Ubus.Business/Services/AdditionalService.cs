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
    public class AdditionalService : BaseService<Additional>, IAdditionalService
    {
        private readonly IAdditionalRepository _additionalRepository;
        private readonly IBusRepository _busRepository;

        public AdditionalService(IAdditionalRepository additionalRepository, INotifier notifier, IBusRepository busRepository) : base(additionalRepository, notifier)
        {
            _additionalRepository = additionalRepository;
            _busRepository = busRepository;
        }

        public override async Task Add(Additional additional)
        {
            if (!ValidationExecute(new AdditionalValidation(), additional)) return;

            await _additionalRepository.Add(additional);
        }

        public override async Task Remove(Guid id)
        {
            var bus = await _busRepository.GetBusByAdditionalId(id);

            if (bus.Count() <= 0)
            {
                Notifier("Não foi possível excluir essa rota, pois há uma Viagem com a mesma.");
                return;
            }

            await _additionalRepository.Remove(id);
        }

        public override async Task Update(Additional additional)
        {
            if (!ValidationExecute(new AdditionalValidation(), additional)) return;

            await _additionalRepository.Update(additional);
        }

    }
}
