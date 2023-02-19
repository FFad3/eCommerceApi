using MediatR;

namespace eCommerceApp.Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
        public bool ShowRemoved;

        public GetAllCategoriesQuery(bool showRemoved)
        {
            ShowRemoved = showRemoved;
        }
    }
}