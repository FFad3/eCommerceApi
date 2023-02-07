using MediatR;

namespace eCommerceApp.Application.Features.Category.Commands.RemoveCategory
{
    public class RemoveCategoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}