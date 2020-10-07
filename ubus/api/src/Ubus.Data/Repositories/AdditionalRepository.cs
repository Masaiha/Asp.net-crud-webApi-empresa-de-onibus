using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class AdditionalRepository : BaseRepository<Additional>, IAdditionalRepository
    {
        public AdditionalRepository(TripContext context) : base(context) { }

        public async Task<IEnumerable<Additional>> GetAllAdditionalsBus()
        {
            return await Db.Additionals.AsNoTracking()
                    .Include(t => t.Bus)
                    .ToListAsync();
        }

        public async Task<Additional> GetByIddditionalsBus(Guid id)
        {
            return await Db.Additionals.AsNoTracking()
                    .Include(t => t.Bus)
                    .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
