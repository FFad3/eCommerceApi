using eCommerceApp.Application.Features.Product.Queries.GetPaginatedProducts;
using eCommerceApp.Domain;
using eCommerceApp.Utilities.Extensions;
using MediatR;

namespace eCommerceApp.Application.Features.Order.Queries.GetOrderPage
{
    public class GetOrderPageQuary : IRequest<PaginatedList<OrderDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 20;
    }
}