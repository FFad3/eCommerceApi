using eCommerceApp.Application.Features.Category.Commands.CreateCategory;
using eCommerceApp.Application.Features.Category.Commands.UpdateCategory;
using eCommerceApp.Application.Features.Category.Queries.GetAllCategories;
using eCommerceApp.Application.Features.Category.Queries.GetSingleCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers.Managment
{
    [Route("api/[area]/[controller]")]
    [Area("Managment")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Categories([FromQuery] bool ShowRemoved = false)
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery(ShowRemoved));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Category(int id)
        {
            var result = await _mediator.Send(new GetSingleCategoryQuery(categoryId: id, showRemoved: true));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}