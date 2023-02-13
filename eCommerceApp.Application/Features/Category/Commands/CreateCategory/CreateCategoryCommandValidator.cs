using eCommerceApp.Application.Contracts.Persistence;
using FluentValidation;

namespace eCommerceApp.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(q => q)
                .MustAsync(CategoryNameIsUnique)
                .WithMessage("Category already exists");
        }

        private async Task<bool> CategoryNameIsUnique(CreateCategoryCommand command, CancellationToken token)
        {
            var result = await _unitOfWork.Category.IsExist(x => x.Name == command.Name, token);
            return !result;
        }
    }
}