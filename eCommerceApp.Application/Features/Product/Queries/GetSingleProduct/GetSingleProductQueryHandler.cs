using AutoMapper;
using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Product.Queries.GetSingleProduct
{
    public class GetSingleProductQueryHandler : IRequestHandler<GetSingleProductQuery, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetSingleProductQueryHandler> _logger;

        public GetSingleProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetSingleProductQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductDto> Handle(GetSingleProductQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Product.FindSingleProductAsync(x => x.Id == request.Id && !x.IsRemoved, cancellationToken) 
                ?? throw new NotFoundException(nameof(Domain.Product), request.Id);

            var result = _mapper.Map<ProductDto>(entity);

            return result;
        }
    }
}