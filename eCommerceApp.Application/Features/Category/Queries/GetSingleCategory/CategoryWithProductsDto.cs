namespace eCommerceApp.Application.Features.Category.Queries.GetSingleCategory
{
    public record CategoryWithProductsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<CategoryProductDto> Products { get; set; } = new List<CategoryProductDto>();
        public int ProductsCount { get; set; } = 0;

        public record CategoryProductDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public string Description { get; set; } = string.Empty;
            public string ImgUrl { get; set; } = string.Empty;
        }
    }
}