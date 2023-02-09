using AutoMapper;
using eCommerceApp.Application.Features.Basket.Queries.GetBasketPage;

namespace eCommerceApp.Application.MappingProfiles
{
    public class BasketItemProfile : Profile
    {
        public BasketItemProfile()
        {
            CreateMap<Domain.BasketItem, BasketDto.BasketItemDto>();
        }
    }
}