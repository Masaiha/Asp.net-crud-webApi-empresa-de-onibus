using System;
using System.Collections;
using System.Collections.Generic;

namespace Ubus.Business.Entities
{
    public class Driver : Employee
    {
        //public Guid TripId { get; set; }
        //public IEnumerable<Trip> Trips { get; set; }

        public TripDriver TripDriver { get; set; }
    }
}
