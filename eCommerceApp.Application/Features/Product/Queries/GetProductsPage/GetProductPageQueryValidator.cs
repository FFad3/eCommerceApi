using FluentValidation;

namespace eCommerceApp.Application.Features.Product.Queries.GetPaginatedProducts
{
    public class GetProductPageQueryValidator : AbstractValidator<GetProductPageQuery>
    {
        public GetProductPageQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater or equal to 0");
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}