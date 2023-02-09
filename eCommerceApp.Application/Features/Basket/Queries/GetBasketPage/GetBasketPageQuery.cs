using eCommerceApp.Utilities.Extensions;
using MediatR;

namespace eCommerceApp.Application.Features.Basket.Queries.GetBasketPage
{
    public class GetBasketPageQuery : IRequest<PaginatedList<BasketDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 20;
    }
}