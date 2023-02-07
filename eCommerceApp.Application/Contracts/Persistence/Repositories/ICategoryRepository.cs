using eCommerceApp.Domain;
using System.Linq.Expressions;

namespace eCommerceApp.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category?> FindSingleWithProductsAsync(Expression<Func<Category, bool>> predicate, CancellationToken token);
    }
}