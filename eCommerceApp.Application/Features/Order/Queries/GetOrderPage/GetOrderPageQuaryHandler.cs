using AutoMapper;
using AutoMapper.QueryableExtensions;
using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Utilities.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Order.Queries.GetOrderPage
{
    public class GetOrderPageQuaryHandler : IRequestHandler<GetOrderPageQuary, PaginatedList<OrderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetOrderPageQuaryHandler> _logger;

        public GetOrderPageQuaryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetOrderPageQuaryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PaginatedList<OrderDto>> Handle(GetOrderPageQuary request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Order.AsQuerable()
                .Include(x => x.Items)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

            return result;
        }
    }
}