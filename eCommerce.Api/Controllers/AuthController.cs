using eCommerceApp.Application.Features.Auth.Commands.Authentication;
using eCommerceApp.Application.Features.Auth.Commands.Refresh;
using eCommerceApp.Application.Features.Auth.Commands.Register;
using eCommerceApp.Application.Models.Identity;
using eCommerceApp.Application.Models.Settings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthCommand request)
        {
            //Set cookies with refresh and access token body expire date & Role np. isAdmin= true/false with http only
            var result = await _mediator.Send(request);

            //Set Tokens as cookies
            SetTokens(result.AccessToken, result.RefreshToken);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegisterCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [Authorize]
        [HttpPost("refresh-token")]
        public async Task<ActionResult<AuthResponse>> RefreshToken()
        {
            var command = new RefreshTokenCommand
            {
                AccessToken = Request.Cookies[JwtTokensNames.AccessToken],
                RefreshToken = Request.Cookies[JwtTokensNames.RefreshToken]
            };
            var result = await _mediator.Send(command);

            //Set Tokens as cookies
            SetTokens(result.AccessToken, result.RefreshToken);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(JwtTokensNames.AccessToken);
            Response.Cookies.Delete(JwtTokensNames.RefreshToken);

            return Ok(new
            {
                message = "success"
            });
        }

        private void SetTokens(string access, string refresh)
        {
            Response.Cookies.Append(JwtTokensNames.AccessToken, access, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
            });
            Response.Cookies.Append(JwtTokensNames.RefreshToken, refresh, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
            });
        }
    }
}