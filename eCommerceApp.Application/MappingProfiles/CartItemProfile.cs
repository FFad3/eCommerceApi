using AutoMapper;
using eCommerceApp.Application.Features.Cart.Queries.GetCurrentUserCart;

namespace eCommerceApp.Application.MappingProfiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<Domain.CartItem, CartItemDto>();
        }
    }
}