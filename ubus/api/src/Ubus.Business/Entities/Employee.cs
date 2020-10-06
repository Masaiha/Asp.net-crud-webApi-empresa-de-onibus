using System;

namespace Ubus.Business.Entities
{
    public abstract class Employee : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Cpf { get; set; }
        //public DateTime Start { get; set; }
        //public DateTime LastUpdated { get; set; }
        //public bool IsAdm { get; set; }
        public bool IsActive { get; set; }
    }
}
