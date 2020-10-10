using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ubus.App.Constantes;
using Ubus.Business.Entities;

namespace Ubus.App.ViewModels
{
    public class TripWithDriverNameViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [JsonIgnore]
        public Guid DriverId { get; set; }

        [JsonIgnore]
        public Guid BusId { get; set; }

        [JsonIgnore]
        public Guid RouteId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Position { get; set; }

        public bool IsFinished { get; set; }

        public DriverViewModel Driver { get; set; }

        public RouteViewModel Route { get; set; }

        public BusViewModel Bus { get; set; }

    }
}
