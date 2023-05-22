namespace eCommerceApp.Application.Features.Cart.Queries.GetCurrentUserCart
{
    public record CartDto
    {
        public int Id { get; set; }
        public IEnumerable<CartItemDto> Items { get; set; } = new List<CartItemDto>();
        public decimal TotalPrice => Items.Sum(x => x.UnitPrice * x.Quantity);
        public int ItemsCount => Items.Sum(x => x.Quantity);
    }
}
