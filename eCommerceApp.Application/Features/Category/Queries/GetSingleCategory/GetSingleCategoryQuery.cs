using MediatR;

namespace eCommerceApp.Application.Features.Category.Queries.GetSingleCategory
{
    public class GetSingleCategoryQuery : IRequest<CategoryWithProductsDto?>
    {
        public int Id { get; set; }
    }
}