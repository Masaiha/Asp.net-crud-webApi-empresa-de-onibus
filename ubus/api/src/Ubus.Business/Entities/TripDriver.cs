using System;
using System.Collections.Generic;

namespace Ubus.Business.Entities
{
    public class TripDriver : Entity
    {
        public Guid DriverId { get; set; }
        public Guid TripId { get; set; }
        public IEnumerable<Driver> Drivers { get; set; }
        //public Driver Driver { get; set; }
        public Trip Trip { get; set; }

    }
}
