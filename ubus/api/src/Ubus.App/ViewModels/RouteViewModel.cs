using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ubus.App.Constantes;

namespace Ubus.App.ViewModels
{
    public class RouteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public string RouteMap { get; set; }

        [JsonIgnore]
        public IEnumerable<TripViewModel> Trips { get; set; }
    }
}
