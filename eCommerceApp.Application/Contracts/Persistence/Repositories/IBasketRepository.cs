using System.Linq.Expressions;
using eCommerceApp.Domain;

namespace eCommerceApp.Application.Contracts.Persistence.Repositories
{
    public interface IBasketRepository : IGenericRepository<Basket>
    {
        Task<Basket?> RetriveBasketWithItemsAsync(Expression<Func<Basket, bool>> predicate, CancellationToken token);
    }
}