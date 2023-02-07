using AutoMapper;
using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Utilities.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Category.AsQuerable()
                .Include(p => p.Products)
                .Where(c => !c.IsRemoved)
                .ProjectToListAsync<CategoryDto>(_mapper.ConfigurationProvider, cancellationToken);

            return result;
        }
    }
}