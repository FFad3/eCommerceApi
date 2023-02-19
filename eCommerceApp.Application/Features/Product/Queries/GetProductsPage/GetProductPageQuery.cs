using eCommerceApp.Application.Features.Product.Queries.GetSingleProduct;
using eCommerceApp.Utilities.Extensions;
using MediatR;

namespace eCommerceApp.Application.Features.Product.Queries.GetPaginatedProducts
{
    public class GetProductPageQuery : IRequest<PaginatedList<ProductDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}