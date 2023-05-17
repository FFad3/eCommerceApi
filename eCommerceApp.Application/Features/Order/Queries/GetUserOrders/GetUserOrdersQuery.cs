using MediatR;

namespace eCommerceApp.Application.Features.Order.Queries.GetUserOrders
{
    public class GetUserOrdersQuery:IRequest<IEnumerable<UserOrderDto>>
    {
    }
}
