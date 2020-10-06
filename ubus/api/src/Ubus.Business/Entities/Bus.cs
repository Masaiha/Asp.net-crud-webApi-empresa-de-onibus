using System;

namespace Ubus.Business.Entities
{
    public class Bus : Entity
    {
        //public Guid AdditionalId { get; set; }
        public string Name { get; set; }

        /* EF Relational */
        public Additional Additional { get; set; }

    }
}
