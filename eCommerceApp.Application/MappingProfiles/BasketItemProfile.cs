using AutoMapper;
using eCommerceApp.Application.Features.Basket.Queries.GetBasketPage;
using eCommerceApp.Application.Features.BasketItem.Queries.GetBasketItems;

namespace eCommerceApp.Application.MappingProfiles
{
    public class BasketItemProfile : Profile
    {
        public BasketItemProfile()
        {
            CreateMap<Domain.BasketItem, BasketDto.BasketItemDto>();
            CreateMap<Domain.BasketItem, BasketItemDto>();
        }
    }
}