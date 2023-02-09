using FluentValidation;

namespace eCommerceApp.Application.Features.Order.Queries.GetOrderPage
{
    public class GetOrderPageQuaryValidator : AbstractValidator<GetOrderPageQuary>
    {
        public GetOrderPageQuaryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater or equal to 0");
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}