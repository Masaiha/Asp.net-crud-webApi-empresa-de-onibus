using FluentValidation;
using Ubus.Business.Entities;
using Ubus.Business.Validations.ErrorMessages;

namespace Ubus.Business.Validations
{
    public class TripValidation : AbstractValidator<Trip>
    {
        public TripValidation()
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty)
                .Length(2, 200).WithMessage(MessagesFluentValidation.Length);

            RuleFor(t => t.Position)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty)
                .Length(2, 500).WithMessage(MessagesFluentValidation.Length);

            RuleFor(t => t.Price)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty);

            RuleFor(t => t.StartDate)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty);

            RuleFor(t => t.EndDate)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty);
        }
    }
}
