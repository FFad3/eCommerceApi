﻿using eCommerceApp.Application.Features.Product.Commands.CreateProduct;
using eCommerceApp.Application.Features.Product.Commands.UpdateProduct;
using eCommerceApp.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers.Managment
{
    [Route("api/[area]/[controller]")]
    [Area("Managment")]
    [ApiController]
    [Authorize(Roles = IdentityDbPopulateConstants.Admin)]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
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