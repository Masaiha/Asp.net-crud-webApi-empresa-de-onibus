using FluentValidation;
using Ubus.Business.Entities;
using Ubus.Business.Validations.ErrorMessages;

namespace Ubus.Business.Validations
{
    public class AdditionalValidation : AbstractValidator<Additional>
    {
        public AdditionalValidation()
        {
            RuleFor(a => a.isHasAirConditioning)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty);            
            
            RuleFor(a => a.isHasBathroom)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty);

            RuleFor(a => a.isHasMinibar)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty);

            RuleFor(a => a.isHaswifi)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty);

        }
    }
}
