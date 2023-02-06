using AutoMapper;
using eCommerceApp.Application.Features.Category.Commands.CreateCategory;

namespace eCommerceApp.Application.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryCommand, Domain.Category>();
        }
    }
}