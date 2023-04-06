using FluentValidation;

namespace eCommerceApp.Application.Features.Auth.Commands.Refresh
{
    public class RefreshTokenCommandValidator:AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x=>x.AccessToken).NotEmpty();
            RuleFor(x=>x.RefreshToken).NotEmpty();
        }
    }
}
