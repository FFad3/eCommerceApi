using AutoMapper;
using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Application.Exceptions;
using MediatR;

namespace eCommerceApp.Application.Features.Order.Commands.PlaceOrderCommand
{
    public class PlaceOrderCommandHandler :IRequestHandler<PlaceOrderCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IDateTimeService _dateService;

        public PlaceOrderCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, IDateTimeService dateService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _mapper = mapper;
            _dateService = dateService;
        }

        public async Task<Unit> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var basket = await _unitOfWork.Cart.RetriveCartWithItemsAsync(c=>c.Id==request.Id&&c.UserId==userId,cancellationToken)
                ?? throw new NotFoundException("Cart doesn't exist");

            var order = _mapper.Map<Domain.Order>(basket);
            //    = new Domain.Order
            //{
            //    OrderDate = _dateService.Now,
            //    Items = _mapper.Map<IList<Domain.OrderItem>>(basket.Items),
            //    UserId = userId,
            //};


            if (order != null)
            {
                order.OrderDate = _dateService.Now;
                await _unitOfWork.Order.CreateAsync(order, cancellationToken);
                _unitOfWork.Cart.Remove(basket);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
