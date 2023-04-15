using eCommerceApp.Application.Contracts.Persistence;
using FluentValidation;

namespace eCommerceApp.Application.Features.BasketItem.Commands.AddBasketItemCommand
{
    public class AddBasketItemCommandValidator : AbstractValidator<AddBasketItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddBasketItemCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.ItemId)
                .NotEmpty().NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x)
                .MustAsync(ProductExist).WithMessage("Product doesn't exist");
        }

        private async Task<bool> ProductExist(AddBasketItemCommand command, CancellationToken token)
        {
            var result = await _unitOfWork.Product.IsExist(x => x.Id == command.ItemId && !x.IsRemoved, token);
            return result;
        }
    }
}