using AutoMapper;
using eCommerceApp.Application.Features.Order.Queries.GetOrderPage;

namespace eCommerceApp.Application.MappingProfiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<Domain.OrderItem, OrderDto.OrderItemDto>();
        }
    }
}