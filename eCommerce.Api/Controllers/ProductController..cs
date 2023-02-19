using eCommerceApp.Application.Features.Product.Commands.CreateProduct;
using eCommerceApp.Application.Features.Product.Commands.UpdateProduct;
using eCommerceApp.Application.Features.Product.Queries.GetPaginatedProducts;
using eCommerceApp.Application.Features.Product.Queries.GetSingleProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetProductPageQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetSingleProductQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}