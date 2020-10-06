using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ubus.Business.Entities;

namespace Ubus.App.ViewModels
{
    public class MiniBarViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
