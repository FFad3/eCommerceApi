using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Application.Contracts.Persistence;
using MediatR;

namespace eCommerceApp.Application.Features.CartItem.Commands.RemoveCartItemCommand
{
    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public RemoveCartItemCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.CartItem.FindSingleAsync(x => x.Id == request.ItemId && !x.IsRemoved, cancellationToken);
            if (item != null)
            {
                _unitOfWork.CartItem.Remove(item);
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
