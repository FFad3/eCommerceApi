using AutoMapper;
using eCommerceApp.Application.Features.Order.Queries.GetOrderPage;

namespace eCommerceApp.Application.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Domain.Order, OrderDto>();
        }
    }
}