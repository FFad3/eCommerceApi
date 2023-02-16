using AutoMapper;
using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Product.Commands.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<RemoveProductCommandHandler> _logger;

        public RemoveProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<RemoveProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var productToRemove = await _unitOfWork.Product.FindSingleAsync(x => x.Id == request.Id, cancellationToken);

            if (productToRemove == null)
                throw new NotFoundException(nameof(Domain.Product), request.Id);

            _unitOfWork.Product.Remove(productToRemove);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}