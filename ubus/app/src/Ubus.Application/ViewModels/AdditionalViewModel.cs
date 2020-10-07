using System;
using System.ComponentModel.DataAnnotations;
using Ubus.Application.Constantes;

namespace Ubus.Application.ViewModels
{
    public class AdditionalViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid BusId { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public bool isHasMinibar { get; set; }
        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public bool isHasAirConditioning { get; set; }
        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public bool isHasBathroom { get; set; }
        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public bool isHaswifi { get; set; }

        public BusViewModel Bus { get; set; }
    }
}
