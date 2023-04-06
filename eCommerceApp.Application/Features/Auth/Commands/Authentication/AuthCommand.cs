using eCommerceApp.Application.Models.Identity;
using MediatR;

namespace eCommerceApp.Application.Features.Auth.Commands.Authentication
{
    public class AuthCommand : IRequest<AuthResponse?>
    {
        public string Email { get; set; } = "user@localhost.com";
        public string Password { get; set; } = null!;
    }
}
