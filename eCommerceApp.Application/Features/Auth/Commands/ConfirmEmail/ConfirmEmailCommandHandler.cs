using eCommerceApp.Application.Contracts.Identity;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Auth.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IAuthService _authService;
        private readonly ILogger<ConfirmEmailCommandHandler> _logger;

        public ConfirmEmailCommandHandler(IAuthService authService, ILogger<ConfirmEmailCommandHandler> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            request.Token = $"{request.Token.Replace(' ', '+')}==";
            var result = await _authService.ConfirmEmail(request);

            if (!result) _logger.LogError($"Faild to confirm user: {request.UserId}");
            else _logger.LogInformation($"User: {request.UserId} confirmation successfull");

            return result;
        }
    }
}
