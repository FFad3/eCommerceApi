using AutoMapper;
using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Category.Commands.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public RemoveCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToRemove = await _unitOfWork.Category.FindSingleAsync(x => x.Id == request.Id, cancellationToken);

            if (categoryToRemove == null)
                throw new NotFoundException(nameof(Domain.Category), request.Id);

            _unitOfWork.Category.Remove(categoryToRemove);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}