using AutoMapper;
using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Application.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Application.Features.Order.Queries.GetUserOrders
{
    public class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, IEnumerable<UserOrderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetUserOrdersQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserOrderDto>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {
            var user = _currentUserService.UserId;

            var orders = await _unitOfWork.Order.AsQuerable()
                .Where(x=>x.UserId==user && !x.IsRemoved)
                .Include(x=>x.Items)
                .Select(c=>new UserOrderDto
                {
                    Id = c.Id,
                    OrderDate = c.OrderDate,
                    TotalPrice= c.Items.Sum(i=>i.UnitPrice*i.Quantity)
                })
                .OrderBy(x=>x.OrderDate)
                .ToListAsync();

            if (orders is null) throw new NotFoundException(nameof(Domain.Order),user);

            return orders;
        }
    }
}
