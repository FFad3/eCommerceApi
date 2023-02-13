using eCommerceApp.Application.Contracts.Persistence;
using FluentValidation;

namespace eCommerceApp.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Id).NotNull();

            RuleFor(p => p.Name)
                           .NotEmpty().WithMessage("{PropertyName} is required")
                           .NotNull()
                           .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(q => q)
                .MustAsync(CategoryNameIsUnique)
                .WithMessage("Leave type already exists");
        }

        private async Task<bool> CategoryNameIsUnique(UpdateCategoryCommand command, CancellationToken token)
        {
            var result = await _unitOfWork.Category.IsExist(x => x.Name == command.Name, token);
            return !result;
        }
    }
}