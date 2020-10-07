using System.Collections.Generic;

namespace Ubus.Application.Business
{
    public class Route : Entity
    {
        public string RouteMap { get; set; }

        public IEnumerable<Trip> Trips { get; set; }
    }

}
