namespace eCommerceApp.Application.Features.Order.Queries.GetOrderPage
{
    public class OrderDto
    {
        public OrderDto()
        {
            Items = new List<OrderItemDto>();
        }

        public ICollection<OrderItemDto> Items { get; set; }
        public DateTime OrderDate { get; set; }

        public class OrderItemDto
        {
            public int OrderId { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }
    }
}