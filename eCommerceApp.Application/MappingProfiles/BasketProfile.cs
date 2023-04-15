using AutoMapper;
using eCommerceApp.Application.Features.Basket.Queries.GetCurrentUserBasket;

namespace eCommerceApp.Application.MappingProfiles
{
    public class BasketProfile :Profile
    {
        public BasketProfile()
        {
            CreateMap<Domain.Basket, BasketDto>();
        }
    }
}