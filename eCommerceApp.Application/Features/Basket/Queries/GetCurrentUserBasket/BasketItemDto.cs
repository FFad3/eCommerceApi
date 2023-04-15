namespace eCommerceApp.Application.Features.Basket.Queries.GetCurrentUserBasket
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total => UnitPrice*Quantity;
    }
}
