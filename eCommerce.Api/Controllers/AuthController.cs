using eCommerceApp.Application.Features.Auth.Commands.Authentication;
using eCommerceApp.Application.Features.Auth.Commands.Refresh;
using eCommerceApp.Application.Features.Auth.Commands.Register;
using eCommerceApp.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegisterCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<AuthResponse>> RefreshToken(RefreshTokenCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}