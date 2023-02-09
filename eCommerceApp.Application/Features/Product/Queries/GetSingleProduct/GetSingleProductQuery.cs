using eCommerceApp.Application.Features.Category.Queries.GetSingleCategory;
using MediatR;

namespace eCommerceApp.Application.Features.Product.Queries.GetSingleProduct
{
    public class GetSingleProductQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}