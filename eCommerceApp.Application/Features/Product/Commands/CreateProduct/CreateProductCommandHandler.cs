using AutoMapper;
using eCommerceApp.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productToCreate = _mapper.Map<Domain.Product>(request);

            var result = await _unitOfWork.Product.CreateAsync(productToCreate, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result.Id;
        }
    }
}