namespace eCommerceApp.Application.Features.Basket.Queries.GetCurrentUserBasket
{
    public class BasketDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<BasketItemDto> Items {get;set;} = new List<BasketItemDto>();
        public decimal TotalPrice => Items.Sum(x => x.UnitPrice * x.Quantity);
        public int ItemsCount => Items.Sum(x=>x.Quantity);
    }
}
