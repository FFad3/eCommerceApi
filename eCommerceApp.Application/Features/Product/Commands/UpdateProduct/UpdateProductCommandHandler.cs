using AutoMapper;
using eCommerceApp.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToCreate = _mapper.Map<Domain.Product>(request);

            _unitOfWork.Product.Update(productToCreate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}