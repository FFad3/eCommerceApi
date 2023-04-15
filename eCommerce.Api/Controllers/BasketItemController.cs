using eCommerceApp.Application.Features.BasketItem.Commands.AddBasketItemCommand;
using eCommerceApp.Application.Features.Category.Commands.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemController:ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(AddBasketItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
