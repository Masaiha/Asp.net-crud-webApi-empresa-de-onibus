using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ubus.Business.Entities;

namespace Ubus.App.ViewModels
{
    public class DriverViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Cpf { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public TripViewModel Trip { get; set; }
    }
}
