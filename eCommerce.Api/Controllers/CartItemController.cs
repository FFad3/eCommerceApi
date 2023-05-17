using eCommerceApp.Application.Features.CartItem.Commands.AddCartItemCommand;
using eCommerceApp.Application.Features.CartItem.Commands.RemoveCartItemCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-item")]
        public async Task<IActionResult> AddItem(AddCartItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("remove-item")]
        public async Task<IActionResult> RemoveItem(RemoveCartItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}