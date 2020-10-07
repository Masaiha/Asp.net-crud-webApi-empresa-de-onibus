using System;
using System.ComponentModel.DataAnnotations;
using Ubus.Application.Constantes;

namespace Ubus.Application.ViewModels
{
    public class BusViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public string Name { get; set; }

        //public Additional MiniBar { get; set; }
    }
}
