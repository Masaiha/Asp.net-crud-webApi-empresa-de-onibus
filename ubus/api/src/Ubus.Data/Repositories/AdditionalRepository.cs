using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class AdditionalRepository : BaseRepository<Additional>, IAdditionalRepository
    {
        public AdditionalRepository(TripContext context) : base(context) { }

    }
}
