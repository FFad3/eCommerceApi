using MediatR;

namespace eCommerceApp.Application.Features.Order.Queries.GetUserOrderDetails
{
    public class GetUserOrderDetailsQuery : IRequest<UserOrderDetailsDto>
    {
        public int Id { get; set; }
    }
}