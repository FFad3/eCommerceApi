using AutoMapper;
using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCategoryCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Category.FindSingleAsync(x => x.Id == request.Id, cancellationToken);

            if (category == null)
                throw new NotFoundException(nameof(Domain.Category), request.Id);

            var categoryToUpdate = _mapper.Map(request, category);

            _unitOfWork.Category.Update(categoryToUpdate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}