using FluentValidation;

namespace eCommerceApp.Application.Features.Auth.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandValidator:AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Token).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
