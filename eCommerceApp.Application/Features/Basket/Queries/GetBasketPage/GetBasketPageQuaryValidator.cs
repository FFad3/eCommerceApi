using FluentValidation;

namespace eCommerceApp.Application.Features.Basket.Queries.GetBasketPage
{
    public class GetBasketPageQuaryValidator : AbstractValidator<GetBasketPageQuery>
    {
        public GetBasketPageQuaryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater or equal to 0");
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}