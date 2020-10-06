using System;
using System.Collections.Generic;

namespace Ubus.Business.Entities
{
    public class MiniBar : Entity
    {
        public IEnumerable<Product> Products { get; private set; }

        /* EF Relational */
        public IEnumerable<Bus> Bus { get; set; }
    }
}
