using eCommerceApp.Application.Contracts.Persistence;
using FluentValidation;

namespace eCommerceApp.Application.Features.CartItem.Commands.AddCartItemCommand
{
    public class AddCartItemCommandValidator : AbstractValidator<AddCartItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCartItemCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.ItemId)
                .NotEmpty().NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x)
                .MustAsync(ProductExist).WithMessage("Product doesn't exist");
        }

        private async Task<bool> ProductExist(AddCartItemCommand command, CancellationToken token)
        {
            var result = await _unitOfWork.Product.IsExist(x => x.Id == command.ItemId && !x.IsRemoved, token);
            return result;
        }
    }
}
