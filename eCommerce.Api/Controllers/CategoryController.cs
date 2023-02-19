using eCommerceApp.Application.Features.Category.Commands.CreateCategory;
using eCommerceApp.Application.Features.Category.Commands.UpdateCategory;
using eCommerceApp.Application.Features.Category.Queries.GetAllCategories;
using eCommerceApp.Application.Features.Category.Queries.GetSingleCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery(showRemoved: false));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Category(int id)
        {
            var result = await _mediator.Send(new GetSingleCategoryQuery(categoryId: id, showRemoved: false));
            return Ok(result);
        }
    }
}