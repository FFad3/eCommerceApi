using eCommerceApp.Application.Features.Order.Commands.PlaceOrderCommand;
using eCommerceApp.Application.Features.Order.Queries.GetUserOrderDetails;
using eCommerceApp.Application.Features.Order.Queries.GetUserOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("confirm")]        
        public async Task<IActionResult> RemoveItem(PlaceOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("orders")]
        public async Task<IActionResult> GetUserOrderList()
        {
            var result = await _mediator.Send(new GetUserOrdersQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserOrderDetails(int id)
        {
            var result = await _mediator.Send(new GetUserOrderDetailsQuery { Id=id});
            return Ok(result);
        }
    }
}
