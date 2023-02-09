using AutoMapper;
using eCommerceApp.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Product.Queries.GetSingleProduct
{
    public class GetSingleProductQueryHandler : IRequestHandler<GetSingleProductQuery, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetSingleProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductDto> Handle(GetSingleProductQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Product.FindSingleAsync(x => x.Id == request.Id && !x.IsRemoved, cancellationToken);

            var result = _mapper.Map<ProductDto>(entity);

            return result;
        }
    }
}