using System;

namespace Ubus.App.Commands.Trip
{
    public class CreateTripDriverCommand
    {
        public Guid DriverId { get; set; }

        public Guid TripId { get; set; }
    }
}
