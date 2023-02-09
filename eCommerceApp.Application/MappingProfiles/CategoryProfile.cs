using AutoMapper;
using eCommerceApp.Application.Features.Category.Commands.CreateCategory;
using eCommerceApp.Application.Features.Category.Commands.UpdateCategory;
using eCommerceApp.Application.Features.Category.Queries.GetAllCategories;
using eCommerceApp.Application.Features.Category.Queries.GetSingleCategory;
using eCommerceApp.Application.Features.Product.Queries.GetSingleProduct;

namespace eCommerceApp.Application.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryCommand, Domain.Category>();
            CreateMap<UpdateCategoryCommand, Domain.Category>();
            CreateMap<Domain.Category, CategoryDto>();
            CreateMap<Domain.Category, CategoryWithProductsDto>();
            CreateMap<Domain.Category, ProductDto.ProductCategoryDto>();
        }
    }
}