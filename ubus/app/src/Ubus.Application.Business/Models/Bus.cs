using System;

namespace Ubus.Application.Business
{
    public class Bus : Entity
    {
        public string Name { get; set; }

        /* EF Relational */
        public Additional Additional { get; set; }

    }
}
