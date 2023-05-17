namespace eCommerceApp.Application.Features.Order.Queries.GetUserOrderDetails
{
    public class UserOrderDetailsDto
    {
        public int Id { get; set; }

        public UserOrderDetailsDto()
        {
            Items = new List<UserOrderDetailsItemDto>();
        }

        public ICollection<UserOrderDetailsItemDto> Items { get; set; }
        public DateTime OrderDate { get; set; }

        public class UserOrderDetailsItemDto
        {
            public int Id { get; set; }
            public int OrderId { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }
    }
}