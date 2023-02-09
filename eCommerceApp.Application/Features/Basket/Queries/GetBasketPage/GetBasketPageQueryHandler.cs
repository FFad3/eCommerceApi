using AutoMapper;
using AutoMapper.QueryableExtensions;
using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Utilities.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Basket.Queries.GetBasketPage
{
    public class GetBasketPageQueryHandler : IRequestHandler<GetBasketPageQuery, PaginatedList<BasketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetBasketPageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PaginatedList<BasketDto>> Handle(GetBasketPageQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Basket.AsQuerable()
                .Include(x => x.Items)
                .ProjectTo<BasketDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

            return result;
        }
    }
}