using AutoMapper;
using eCommerceApp.Application.Features.Order.Queries;
using eCommerceApp.Application.Features.Order.Queries.GetOrderPage;
using eCommerceApp.Application.Features.Order.Queries.GetUserOrderDetails;

namespace eCommerceApp.Application.MappingProfiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<Domain.OrderItem, OrderDto.OrderItemDto>();
            CreateMap<Domain.OrderItem, UserOrderDetailsDto.UserOrderDetailsItemDto>();
        }
    }
}