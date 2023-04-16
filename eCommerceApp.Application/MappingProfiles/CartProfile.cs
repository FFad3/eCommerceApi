using AutoMapper;
using eCommerceApp.Application.Features.Cart.Queries.GetCurrentUserCart;

namespace eCommerceApp.Application.MappingProfiles
{
    public class CartProfile :Profile
    {
        public CartProfile()
        {
            CreateMap<Domain.Cart, CartDto>();
        }
    }
}