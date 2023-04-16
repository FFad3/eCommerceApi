using MediatR;

namespace eCommerceApp.Application.Features.CartItem.Commands.AddCartItemCommand
{
    public class AddCartItemCommand : IRequest<Unit>
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
