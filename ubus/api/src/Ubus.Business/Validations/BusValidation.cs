using FluentValidation;
using Ubus.Business.Entities;
using Ubus.Business.Validations.ErrorMessages;

namespace Ubus.Business.Validations
{
    public class BusValidation : AbstractValidator<Bus>
    {
        public BusValidation()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty)
                .Length(2, 200).WithMessage(MessagesFluentValidation.Length);

        }
    }
}
