using System.Collections.Generic;

namespace Ubus.Business.Entities
{
    public class Route : Entity
    {
        public string RouteMap { get; set; }

        public IEnumerable<Trip> Trips { get; set; }
    }

}
