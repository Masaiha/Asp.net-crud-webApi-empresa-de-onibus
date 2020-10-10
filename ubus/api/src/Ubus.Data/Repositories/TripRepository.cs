using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class TripRepository : BaseRepository<Trip>, ITripRepository
    {
        private readonly IDriverRepository _driverRepository;

        public TripRepository(TripContext context, IDriverRepository driverRepository) : base(context)
        {
            _driverRepository = driverRepository;
        }

        public async Task<IEnumerable<TripWithDriverName>> GetAllTrips()
        {
            var _listTripWithDriverName = new List<TripWithDriverName>();

            var t = await Db.Trips.AsNoTracking()
                    .Include(t => t.Bus)
                    .Include(t => t.Route)
                    .Include(t => t.TripDriver)
                    .ThenInclude(td => td.Drivers)
                    .ToListAsync();

            foreach (var item in t)
            {
                var _driver = item.TripDriver;

                _listTripWithDriverName.Add(new TripWithDriverName()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Position = item.Position,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Bus = item.Bus,
                    Route = item.Route,
                    Driver = item.TripDriver != null ?_driverRepository.GetById(item.TripDriver.DriverId).Result : null,
                    IsFinished = item.IsFinished
                });
            }

            return _listTripWithDriverName.OrderBy(t => t.Name);
        }

        public async Task<Trip> GetByIdWithRouteDriverBus(Guid id)
        {            
            return await Db.Trips.AsNoTracking()
                    .Include(t => t.Bus)
                    .Include(t => t.Route)
                    .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Trip>> GetTripByBusId(Guid id)
        {
            return await FindByExpression(t => t.BusId == id);
        }

        public async Task<IEnumerable<Trip>> GetTripByRoutId(Guid id)
        {
            return await FindByExpression(t => t.RouteId == id);
        }

        public async Task UpdateAllTripsFinished()
        {
            var trips = from t in Db.Trips
                        where t.EndDate < DateTime.Now
                        select t;

            foreach (var item in trips)
            {
                item.IsFinished = true;
                await Update(item);
            }

            return;
        }

    }
}
