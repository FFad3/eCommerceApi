﻿using eCommerceApp.Application.Contracts.Persistence;
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

            RuleFor(r => r)
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(q => q)
                .MustAsync(CategoryNameIsUnique)
                .WithMessage("Category name already used");
        }

        private async Task<bool> CategoryNameIsUnique(UpdateCategoryCommand command, CancellationToken token)
        {
            var result = await _unitOfWork.Category.FindAllAsync(x => x.Name == command.Name, token);

            if (!result.Any()) return true;

            return result.Count() <= 1 && result.First().Id == command.Id;
        }
    }
}