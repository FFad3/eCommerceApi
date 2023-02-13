using eCommerceApp.Application.Contracts.Persistence;
using FluentValidation;

namespace eCommerceApp.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(c => c.CategoryId)
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(d => d.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MinimumLength(50).WithMessage("{PropertyName} must be higher than 50 characters")
                .MaximumLength(500).WithMessage("{PropertyName} must be fewer than 500 characters");

            RuleFor(d => d.ImgUrl)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MinimumLength(15).WithMessage("{PropertyName} must be higher than 50 characters")
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 500 characters");

            RuleFor(n => n)
                   .MustAsync(ProductNameIsUnique).WithMessage("Product already exists")
                   .MustAsync(CategoryExists).WithMessage("Category doesnt exists");
        }

        private async Task<bool> ProductNameIsUnique(CreateProductCommand command, CancellationToken token)
        {
            var result = await _unitOfWork.Product.IsExist(x => x.Name == command.Name, token);
            return !result;
        }

        private Task<bool> CategoryExists(CreateProductCommand command, CancellationToken token)
        {
            return _unitOfWork.Category.IsExist(x => x.Id == command.CategoryId && !x.IsRemoved, token);
        }
    }
}