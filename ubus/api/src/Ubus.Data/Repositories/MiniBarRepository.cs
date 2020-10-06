using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class MiniBarRepository : BaseRepository<MiniBar>, IMiniBarRepository
    {
        public MiniBarRepository(TripContext context) : base(context) { }
    }
}
