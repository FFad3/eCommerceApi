using AutoMapper;
using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Cart.Queries.GetCurrentUserCart
{
    public class GetCurrentUserCartQueryHandler : IRequestHandler<GetCurrentUserCartQuery, CartDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetCurrentUserCartQueryHandler> _logger;

        public GetCurrentUserCartQueryHandler(ICurrentUserService currentUserService, IMapper mapper, IUnitOfWork unitOfWork, ILogger<GetCurrentUserCartQueryHandler> logger)
        {
            _currentUserService = currentUserService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<CartDto> Handle(GetCurrentUserCartQuery request, CancellationToken cancellationToken)
        {
            var _user = _currentUserService.UserId;
            var cart = await _unitOfWork.Cart.RetriveCartWithItemsAsync(x => x.UserId == _user && !x.IsRemoved, cancellationToken);
            //Creates new cart if no exist
            if (cart == null)
            {
                var newCart = new Domain.Cart()
                {
                    UserId = _user
                };
                cart = await _unitOfWork.Cart.CreateAsync(newCart, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return _mapper.Map<CartDto>(cart);
        }
    }
}
