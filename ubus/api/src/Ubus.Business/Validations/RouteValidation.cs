using FluentValidation;
using Ubus.Business.Entities;
using Ubus.Business.Validations.ErrorMessages;

namespace Ubus.Business.Validations
{
    class RouteValidation : AbstractValidator<Route>
    {
        public RouteValidation()
        {
            RuleFor(r => r.RouteMap)
                .NotEmpty().WithMessage(MessagesFluentValidation.NotEmpty)
                .Length(2, 500).WithMessage(MessagesFluentValidation.Length);

        }
    }
}
