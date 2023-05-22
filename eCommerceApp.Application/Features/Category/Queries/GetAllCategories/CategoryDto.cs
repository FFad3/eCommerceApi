namespace eCommerceApp.Application.Features.Category.Queries.GetAllCategories
{
    public record CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ProductsCount { get; set; } = 0;
        public bool isRemoved { get; set; }
    }
}