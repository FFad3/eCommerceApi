using AutoMapper;
using eCommerceApp.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Category.Queries.GetSingleCategory
{
    public class GetSingleCategoryQueryHandler : IRequestHandler<GetSingleCategoryQuery, CategoryWithProductsDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetSingleCategoryQueryHandler> _logger;

        public GetSingleCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetSingleCategoryQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CategoryWithProductsDto?> Handle(GetSingleCategoryQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Category.FindSingleWithProductsAsync(x => x.Id == request.CategoryId && x.IsRemoved == request.ShowRemoved, cancellationToken);

            var result = _mapper.Map<CategoryWithProductsDto>(entity);

            return result;
        }
    }
}