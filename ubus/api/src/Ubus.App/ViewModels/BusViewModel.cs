using System;
using System.ComponentModel.DataAnnotations;
using Ubus.App.Constantes;

namespace Ubus.App.ViewModels
{
    public class BusViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public string Name { get; set; }

        public MiniBarViewModel MiniBar { get; set; }
    }
}
