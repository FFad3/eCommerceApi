using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Application.Contracts.Persistence;
using MediatR;

namespace eCommerceApp.Application.Features.BasketItem.Commands.AddBasketItemCommand
{
    public class AddBasketItemCommandHandler : IRequestHandler<AddBasketItemCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public AddBasketItemCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            var user = _currentUserService.UserId;
            var item = await _unitOfWork.Product.FindSingleAsync(x => x.Id == request.ItemId && !x.IsRemoved, cancellationToken);
            var basket = await _unitOfWork.Basket.FindSingleAsync(x => x.UserId == user && !x.IsRemoved, cancellationToken);

            if (item == null || basket == null)
                return Unit.Value;

            var newBasketItem = new Domain.BasketItem()
            {
                BasketId = basket.Id,
                ProductId = item.Id,
                ProductName = item.Name,
                UnitPrice = item.Price,
                Quantity = request.Quantity,
            };

            await _unitOfWork.BasketItem.CreateAsync(newBasketItem, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}