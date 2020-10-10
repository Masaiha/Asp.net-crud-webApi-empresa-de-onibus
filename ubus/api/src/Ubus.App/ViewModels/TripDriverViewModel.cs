using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ubus.App.Constantes;
using Ubus.Business.Entities;

namespace Ubus.App.ViewModels
{
    public class TripDriverViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid DriverId { get; set; }

        public Guid TripId { get; set; }

    }
}
