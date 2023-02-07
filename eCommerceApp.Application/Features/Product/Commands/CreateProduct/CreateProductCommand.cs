using MediatR;

namespace eCommerceApp.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
    }
}