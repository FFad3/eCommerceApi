using eCommerceApp.Application.Contracts.Identity;
using eCommerceApp.Application.Models.Identity;
using MediatR;

namespace eCommerceApp.Application.Features.Auth.Commands.Authentication
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, AuthResponse?>
    {
        private readonly IAuthService _authService;

        public AuthCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthResponse?> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.Login(request);
            return result;
        }
    }
}
