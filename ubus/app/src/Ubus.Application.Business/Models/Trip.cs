using System;

namespace Ubus.Application.Business
{
    public class Trip : Entity
    {
        public Guid DriverId { get; set; }
        public Guid BusId { get; set; }
        public Guid RouteId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Driver Driver { get; set; }
        public Route Route { get; set; }
        public Bus Bus { get; set; }
        public bool IsFinished { get; set; }
    }
}
