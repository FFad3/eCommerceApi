using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Application.Contracts.Persistence;
using MediatR;

namespace eCommerceApp.Application.Features.CartItem.Commands.AddCartItemCommand
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public AddCartItemCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            var user = _currentUserService.UserId;
            var item = await _unitOfWork.Product.FindSingleAsync(x => x.Id == request.ItemId && !x.IsRemoved, cancellationToken);
            var cart = await _unitOfWork.Cart.FindSingleAsync(x => x.UserId == user && !x.IsRemoved, cancellationToken);

            if (item == null || cart == null)
                return Unit.Value;

            var newCartItem = new Domain.CartItem()
            {
                CartId = cart.Id,
                ProductId = item.Id,
                ProductName = item.Name,
                UnitPrice = item.Price,
                Quantity = request.Quantity,
            };

            await _unitOfWork.CartItem.CreateAsync(newCartItem, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
