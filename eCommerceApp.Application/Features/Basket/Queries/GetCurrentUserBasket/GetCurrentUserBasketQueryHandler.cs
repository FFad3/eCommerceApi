using AutoMapper;
using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Basket.Queries.GetCurrentUserBasket
{
    public class GetCurrentUserBasketQueryHandler : IRequestHandler<GetCurrentUserBasketQuery, BasketDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetCurrentUserBasketQueryHandler> _logger;

        public GetCurrentUserBasketQueryHandler(ICurrentUserService currentUserService, IMapper mapper, IUnitOfWork unitOfWork, ILogger<GetCurrentUserBasketQueryHandler> logger = null)
        {
            _currentUserService = currentUserService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<BasketDto> Handle(GetCurrentUserBasketQuery request, CancellationToken cancellationToken)
        {
            var _user = _currentUserService.UserId;
            var basket = await _unitOfWork.Basket.RetriveBasketWithItemsAsync(x=>x.UserId==_user && !x.IsRemoved, cancellationToken);
            //Creates new basket if no exist
            if(basket == null)
            {
                var newBasket = new Domain.Basket()
                {
                    UserId = _user
                };
                basket = await _unitOfWork.Basket.CreateAsync(newBasket, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return _mapper.Map<BasketDto>(basket);
        }
    }
}
