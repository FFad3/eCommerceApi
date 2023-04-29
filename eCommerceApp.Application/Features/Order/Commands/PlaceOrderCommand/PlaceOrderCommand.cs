using MediatR;

namespace eCommerceApp.Application.Features.Order.Commands.PlaceOrderCommand
{
    public class PlaceOrderCommand :IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
