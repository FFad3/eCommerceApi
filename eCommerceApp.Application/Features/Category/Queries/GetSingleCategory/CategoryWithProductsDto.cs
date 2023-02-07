namespace eCommerceApp.Application.Features.Category.Queries.GetSingleCategory
{
    public class CategoryWithProductsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
        public int ProductsCount { get; set; } = 0;
    }
}