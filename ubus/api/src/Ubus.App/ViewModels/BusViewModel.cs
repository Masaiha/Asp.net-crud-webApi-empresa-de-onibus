using System;
using System.ComponentModel.DataAnnotations;

namespace Ubus.App.ViewModels
{
    public class BusViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public MiniBarViewModel MiniBar { get; set; }
    }
}
