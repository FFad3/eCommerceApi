using FluentValidation;

namespace eCommerceApp.Application.Features.Order.Queries.GetUserOrderDetails
{
    public class GetUserOrderDetailsQueryValidator : AbstractValidator<GetUserOrderDetailsQuery>
    {
        public GetUserOrderDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Order id is required");
        }
    }
}
