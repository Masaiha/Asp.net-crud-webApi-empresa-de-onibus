using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ubus.Application.Constantes;

namespace Ubus.Application.ViewModels
{
    public class DriverViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        [StringLength(200, ErrorMessage = MensagemDeErrosViewModel.campoMaxEMinCaracteres, MinimumLength = 3)]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        [MaxLength(ErrorMessage = MensagemDeErrosViewModel.campo11Caracteres)]
        public string Cpf { get; set; }

        public bool IsActive { get; set; }

        [JsonIgnore]
        public TripViewModel Trip { get; set; }
    }
}
