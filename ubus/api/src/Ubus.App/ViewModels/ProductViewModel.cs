using System;
using System.ComponentModel.DataAnnotations;
using Ubus.App.Constantes;
using Ubus.Business.Entities;

namespace Ubus.App.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        [StringLength(200, ErrorMessage = MensagemDeErrosViewModel.campoMaxEMinCaracteres, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public string brand { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public decimal Price { get; set; }

        //public Guid MiniBarId { get; set; }

        //public IEnumerable<string> Products { get; set; }

        //public MiniBarViewModel MiniBar { get; set; }
    }
}
