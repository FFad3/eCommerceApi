using FluentValidation;

namespace eCommerceApp.Application.Features.Auth.Commands.Authentication
{
    public class AuthCommandValidator : AbstractValidator<AuthCommand>
    {
        public AuthCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("Incorrect email adress");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MinimumLength(6).WithMessage("{PropertyName} minimum 6 symbols");
        }
    }
}
