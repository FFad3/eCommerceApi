using AutoMapper;
using eCommerceApp.Application.Features.Cart.Queries.GetCurrentUserCart;

namespace eCommerceApp.Application.MappingProfiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<Domain.CartItem, CartItemDto>();
            CreateMap<Domain.CartItem, Domain.OrderItem>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.IsRemoved, opt => opt.Ignore())
                .ForMember(x => x.CreatedDate, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedDate, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());
        }
    }
}