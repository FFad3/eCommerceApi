using FluentValidation;

namespace eCommerceApp.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("Incorrect email adress");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MinimumLength(6).WithMessage("{PropertyName} minimum 6 symbols");

            RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .MinimumLength(6).WithMessage("{PropertyName} minimum 6 symbols");

            RuleFor(x => x.FirstName)
               .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.ConfirmationUrl)
                 .NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}