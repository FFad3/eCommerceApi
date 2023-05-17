namespace eCommerceApp.Application.Features.Order.Queries.GetUserOrders
{
    public class UserOrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
