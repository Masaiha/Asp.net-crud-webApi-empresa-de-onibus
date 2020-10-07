using FluentValidation;
using Ubus.Business.Entities;
using Ubus.Business.Validations.ErrorMessages;

namespace Ubus.Business.Validations
{
    public class DriverValidation : AbstractValidator<Driver>
    {
        public DriverValidation()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty)
                .Length(2, 200).WithMessage(MessagesFluentValidation.Length);

            RuleFor(d => d.Cpf.Length).Equal(CpfValidation.TamanhoCpf)
                .WithMessage(MessagesFluentValidation.CpfLength);
            
            RuleFor(d => CpfValidation.Validar(d.Cpf)).Equal(true)
                .WithMessage(MessagesFluentValidation.CpfInvalid);

            RuleFor(d => d.Age)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty);
            
        }
    }
}
