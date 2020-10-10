using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using Ubus.App.Constantes;

namespace Ubus.App.Commands.Trip
{
    public class CreateTripCommand
    {

        public Guid DriverId { get; set; }

        public Guid BusId { get; set; }

        public Guid RouteId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        [StringLength(200, ErrorMessage = MensagemDeErrosViewModel.campoMaxEMinCaracteres, MinimumLength = 3)]
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Price { get; set; }

        //public bool IsFinished { get; set; }
    }
}
