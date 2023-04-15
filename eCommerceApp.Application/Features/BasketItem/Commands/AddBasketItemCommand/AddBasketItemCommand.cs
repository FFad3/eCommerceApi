using MediatR;

namespace eCommerceApp.Application.Features.BasketItem.Commands.AddBasketItemCommand
{
    public class AddBasketItemCommand : IRequest<Unit>
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}