using eCommerceApp.Application.Features.Product.Commands.CreateProduct;
using MediatR;

namespace eCommerceApp.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
    }
}