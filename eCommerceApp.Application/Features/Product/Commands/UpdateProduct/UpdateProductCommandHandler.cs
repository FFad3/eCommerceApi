using AutoMapper;
using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Product.FindSingleAsync(x => x.Id == request.Id, cancellationToken);

            if (product == null)
                throw new NotFoundException(nameof(Domain.Product), request.Id);

            var productToUpdate = _mapper.Map(request, product);

            _unitOfWork.Product.Update(productToUpdate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}