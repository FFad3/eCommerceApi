using MediatR;

namespace eCommerceApp.Application.Features.Category.Queries.GetSingleCategory
{
    public class GetSingleCategoryQuery : IRequest<CategoryWithProductsDto?>
    {
        public int CategoryId;
        public bool ShowRemoved;

        public GetSingleCategoryQuery(int categoryId, bool showRemoved)
        {
            CategoryId = categoryId;
            ShowRemoved = showRemoved;
        }
    }
}