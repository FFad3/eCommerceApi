using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Application.Contracts.Persistence;
using FluentValidation;

namespace eCommerceApp.Application.Features.CartItem.Commands.RemoveCartItemCommand
{
    public class RemoveCartItemCommandValidator : AbstractValidator<RemoveCartItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        public RemoveCartItemCommandValidator(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;

            RuleFor(x => x.ItemId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(c => c.ItemId)
                .MustAsync(ItemExist).WithMessage("{PropertyName} was not found");
        }

        private async Task<bool> ItemExist(int itemId, CancellationToken token)
        {
            var cart = await _unitOfWork.Cart.FindSingleAsync(x => x.UserId == _currentUserService.UserId, token);

            if (cart == null)
                return false;

            var result = await _unitOfWork.CartItem.IsExist(x => x.Id == itemId && x.CartId == cart.Id && !x.IsRemoved, token);
            return result;
        }
    }
}
