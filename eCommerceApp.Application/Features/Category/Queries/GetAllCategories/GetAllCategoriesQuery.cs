using MediatR;

namespace eCommerceApp.Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}