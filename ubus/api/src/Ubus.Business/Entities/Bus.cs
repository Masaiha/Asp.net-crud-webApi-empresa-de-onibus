using System;

namespace Ubus.Business.Entities
{
    public class Bus : Entity
    {
        public Guid MiniBarId { get; set; }
        public string Name { get; set; }

        /* EF Relational */
        public MiniBar MiniBar { get; set; }

    }
}
