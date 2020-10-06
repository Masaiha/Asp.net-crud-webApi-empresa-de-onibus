using System;

namespace Ubus.Business.Entities
{
    public class Driver : Employee
    {
        public Trip Trip { get; set; }
    }
}
