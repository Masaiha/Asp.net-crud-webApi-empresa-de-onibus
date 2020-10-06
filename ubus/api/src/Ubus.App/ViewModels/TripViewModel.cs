using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ubus.App.Constantes;
using Ubus.Business.Entities;

namespace Ubus.App.ViewModels
{
    public class TripViewModel
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

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        [StringLength(200, ErrorMessage = MensagemDeErrosViewModel.campoMaxEMinCaracteres, MinimumLength = 3)]
        public string Name { get; set; }

        public DriverViewModel Driver { get; set; }

        public RouteViewModel Route { get; set; }

        public BusViewModel Bus { get; set; }

        public bool IsFinished { get; set; }
    }
}
