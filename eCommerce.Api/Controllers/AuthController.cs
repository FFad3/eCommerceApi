using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Application.Features.Auth.Commands.Authentication;
using eCommerceApp.Application.Features.Auth.Commands.ConfirmEmail;
using eCommerceApp.Application.Features.Auth.Commands.Refresh;
using eCommerceApp.Application.Features.Auth.Commands.Register;
using eCommerceApp.Application.Models.Email;
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
        private readonly IEmailService _emailService;
        public AuthController(IMediator mediator, ILogger<AuthController> logger, IEmailService emailService)
        {
            _mediator = mediator;
            _logger = logger;
            _emailService = emailService;
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
        public async Task<IActionResult> Register(RegisterCommand request)
        {
            var result = await _mediator.Send(request);


            var message = new EmailMessage
            {
                To = result.Email,
                Subject = "ECommerceShopEmailConfirmation",
                Body = $"{request.ConfirmationUrl}?{result.ToUrlParams}"
            };
            await _emailService.SendEmail(message);
            return Ok();
        }
        [AllowAnonymous]
        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail([FromQuery]ConfirmEmailCommand request)
        {
            var result = await _mediator.Send(request);
            return result ? Ok(result) : BadRequest();
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