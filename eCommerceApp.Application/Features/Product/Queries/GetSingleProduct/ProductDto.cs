namespace eCommerceApp.Application.Features.Product.Queries.GetSingleProduct
{
    public record ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ProductCategoryDto? Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;

        public record ProductCategoryDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }
    }
}