using AutoMapper;
using eCommerceApp.Application.Features.Order.Queries.GetOrderPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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