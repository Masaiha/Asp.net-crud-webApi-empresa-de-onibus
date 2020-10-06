using System;
using System.ComponentModel.DataAnnotations;
using Ubus.Business.Entities;

namespace Ubus.App.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        //public Guid MiniBarId { get; set; }
        public string Name { get; set; }
        public string brand { get; set; }
        public decimal Price { get; set; }

        //public IEnumerable<string> Products { get; set; }

        /* EF Relational */
        //public MiniBarViewModel MiniBar { get; set; }
    }
}
