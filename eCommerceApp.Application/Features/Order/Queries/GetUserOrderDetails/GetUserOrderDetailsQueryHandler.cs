using AutoMapper;
using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Application.Features.Order.Queries.GetUserOrderDetails
{
    public class GetUserOrderDetailsQueryHandler : IRequestHandler<GetUserOrderDetailsQuery, UserOrderDetailsDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetUserOrderDetailsQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<UserOrderDetailsDto> Handle(GetUserOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = _currentUserService.UserId;

            var orderDetails = await _unitOfWork.Order.AsQuerable()
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.UserId == user && !x.IsRemoved && x.Id == request.Id, cancellationToken);

            if (orderDetails is null) throw new NotFoundException(nameof(Domain.Order), request.Id);

            return _mapper.Map<UserOrderDetailsDto>(orderDetails);
        }
    }
}