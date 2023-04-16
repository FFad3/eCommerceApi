using System.Linq.Expressions;
using eCommerceApp.Domain;

namespace eCommerceApp.Application.Contracts.Persistence.Repositories
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart?> RetriveCartWithItemsAsync(Expression<Func<Cart, bool>> predicate, CancellationToken token);
    }
}