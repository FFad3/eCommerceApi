using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using eCommerceApp.Application.Features.Cart.Queries.GetCurrentUserCart;

namespace eCommerceApp.Application.MappingProfiles
{
    public class CartProfile :Profile
    {
        public CartProfile()
        {
            CreateMap<Domain.Cart, CartDto>();
            CreateMap<Domain.Cart, Domain.Order>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.IsRemoved, opt => opt.Ignore())
                .ForMember(x => x.CreatedDate, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedDate, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());
        }
    }
}