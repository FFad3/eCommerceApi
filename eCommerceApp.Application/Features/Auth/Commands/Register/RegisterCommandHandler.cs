using eCommerceApp.Application.Contracts.Identity;
using eCommerceApp.Application.Models.Identity;
using MediatR;

namespace eCommerceApp.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegistrationResponse>
    {
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RegistrationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.Register(request);
            return result;
        }
    }
}