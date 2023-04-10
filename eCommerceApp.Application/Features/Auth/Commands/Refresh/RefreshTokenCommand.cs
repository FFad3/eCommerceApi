using eCommerceApp.Application.Models.Identity;
using MediatR;

namespace eCommerceApp.Application.Features.Auth.Commands.Refresh
{
    public class RefreshTokenCommand:IRequest<AuthResponse>
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        }
}
