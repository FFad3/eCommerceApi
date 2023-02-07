using AutoMapper;
using eCommerceApp.Application.Features.Product.Commands.CreateProduct;
using eCommerceApp.Application.Features.Product.Commands.UpdateProduct;

namespace eCommerceApp.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Domain.Product>();
            CreateMap<UpdateProductCommand, Domain.Product>();
        }
    }
}