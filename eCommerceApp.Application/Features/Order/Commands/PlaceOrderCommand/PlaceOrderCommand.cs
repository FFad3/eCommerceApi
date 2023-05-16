using MediatR;

namespace eCommerceApp.Application.Features.Order.Commands.PlaceOrderCommand
{
    public class PlaceOrderCommand :IRequest<Unit>
    {
        public int cartId { get; set; }
    }
}
