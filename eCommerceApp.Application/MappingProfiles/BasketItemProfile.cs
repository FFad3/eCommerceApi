using AutoMapper;
using eCommerceApp.Application.Features.Basket.Queries.GetCurrentUserBasket;

namespace eCommerceApp.Application.MappingProfiles
{
    public class BasketItemProfile : Profile
    {
        public BasketItemProfile()
        {
            CreateMap<Domain.BasketItem, BasketItemDto>();
        }
    }
}