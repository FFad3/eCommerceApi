using MediatR;

namespace eCommerceApp.Application.Features.CartItem.Commands.RemoveCartItemCommand
{
    public class RemoveCartItemCommand : IRequest<Unit>
    {
        public int ItemId { get; set; }
    }
}
