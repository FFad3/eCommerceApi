using FluentValidation;

namespace eCommerceApp.Application.Features.Order.Commands.PlaceOrderCommand
{
    public class PlaceOrderCommandValidator:AbstractValidator<PlaceOrderCommand> 
    {
        public PlaceOrderCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{propertyName} is required");
        }
    }
}
