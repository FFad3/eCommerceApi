using AutoMapper;
using eCommerceApp.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToCreate = _mapper.Map<Domain.Category>(request);

            var result = await _unitOfWork.Category.CreateAsync(categoryToCreate, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result.Id;
        }
    }
}