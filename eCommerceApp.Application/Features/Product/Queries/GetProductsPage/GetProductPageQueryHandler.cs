using AutoMapper;
using AutoMapper.QueryableExtensions;
using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Application.Features.Product.Queries.GetSingleProduct;
using eCommerceApp.Utilities.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Product.Queries.GetPaginatedProducts
{
    public class GetProductPageQueryHandler : IRequestHandler<GetProductPageQuery, PaginatedList<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductPageQueryHandler> _logger;

        public GetProductPageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetProductPageQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PaginatedList<ProductDto>> Handle(GetProductPageQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Product.AsQuerable()
                .Include(x => x.Category)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

            return result;
        }
    }
}