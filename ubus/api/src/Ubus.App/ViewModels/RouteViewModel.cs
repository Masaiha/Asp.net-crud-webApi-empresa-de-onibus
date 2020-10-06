using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ubus.Business.Entities;

namespace Ubus.App.ViewModels
{
    public class RouteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string RouteMap { get; set; }

        [JsonIgnore]
        public IEnumerable<TripViewModel> Trips { get; set; }
    }
}
