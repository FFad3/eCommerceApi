using AutoMapper;
using eCommerceApp.Application.Features.Order.Queries.GetOrderPage;
using eCommerceApp.Application.Features.Order.Queries.GetUserOrderDetails;

namespace eCommerceApp.Application.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Domain.Order, OrderDto>();
            CreateMap<Domain.Order, UserOrderDetailsDto>();
        }
    }
}