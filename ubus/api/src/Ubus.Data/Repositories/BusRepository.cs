using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class BusRepository : BaseRepository<Bus>, IBusRepository
    {
        public BusRepository(TripContext context) : base(context) { }

        public async Task<IEnumerable<Bus>> GetAllBusMinibars()
        {
            var teste = await Db.Bus.AsNoTracking()
                    .Include(x => x.MiniBar)
                    .Include(y => y.MiniBar.Products)
                    .ToListAsync();

            return teste;
        }

    }
}
