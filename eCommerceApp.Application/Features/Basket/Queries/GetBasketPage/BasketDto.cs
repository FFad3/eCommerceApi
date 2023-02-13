namespace eCommerceApp.Application.Features.Basket.Queries.GetBasketPage
{
    public class BasketDto
    {
        public int Id { get; set; }

        public BasketDto()
        {
            Items = new List<BasketItemDto>();
        }

        public ICollection<BasketItemDto> Items { get; set; }

        public class BasketItemDto
        {
            public int Id { get; set; }
            public int BasketId { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }
    }
}