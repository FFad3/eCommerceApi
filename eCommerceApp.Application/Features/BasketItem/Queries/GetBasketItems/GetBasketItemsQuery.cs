using MediatR;

namespace eCommerceApp.Application.Features.BasketItem.Queries.GetBasketItems
{
    public class GetBasketItemsQuery : IRequest<IEnumerable<BasketItemDto>>
    {
        public int BasketId { get; set; }
    }
}