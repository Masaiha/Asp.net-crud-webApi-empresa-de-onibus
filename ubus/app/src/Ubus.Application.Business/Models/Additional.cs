using System;

namespace Ubus.Application.Business
{
    public class Additional : Entity
    {
        public Guid BusId { get; set; }
        public bool isHasMinibar { get; set; }
        public bool isHasAirConditioning { get; set; }
        public bool isHasBathroom { get; set; }
        public bool isHaswifi { get; set; }

        public Bus Bus { get; set; }
    }
}
