using AutoMapper;
using eCommerceApp.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.BasketItem.Queries.GetBasketItems
{
    public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQuery, IEnumerable<BasketItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetBasketItemsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetBasketItemsQueryHandler(IUnitOfWork unitOfWork, ILogger<GetBasketItemsQueryHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BasketItemDto>> Handle(GetBasketItemsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.BasketItem.FindAllAsync(b => b.BastekId == request.BasketId && !b.IsRemoved, cancellationToken);

            var result = _mapper.Map<IEnumerable<BasketItemDto>>(entities);
            return result;
        }
    }
}