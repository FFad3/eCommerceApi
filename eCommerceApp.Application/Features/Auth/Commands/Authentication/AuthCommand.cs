using eCommerceApp.Application.Models.Identity;
using MediatR;

namespace eCommerceApp.Application.Features.Auth.Commands.Authentication
{
    public class AuthCommand : IRequest<AuthResponse>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
