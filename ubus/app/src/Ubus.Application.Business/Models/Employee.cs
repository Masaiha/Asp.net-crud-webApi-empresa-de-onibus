using System;

namespace Ubus.Application.Business
{
    public abstract class Employee : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Cpf { get; set; }
        public bool IsActive { get; set; }
    }
}
