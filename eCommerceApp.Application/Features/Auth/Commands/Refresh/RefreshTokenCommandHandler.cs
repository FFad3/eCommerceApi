using eCommerceApp.Application.Contracts.Identity;
using eCommerceApp.Application.Models.Identity;
using MediatR;

namespace eCommerceApp.Application.Features.Auth.Commands.Refresh
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthResponse>
    {
        private readonly IAuthService _authService;

        public RefreshTokenCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.RefreshToken(request);
            return result;
        }
    }
}
