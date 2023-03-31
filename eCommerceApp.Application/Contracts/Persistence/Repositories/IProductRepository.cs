using System.Linq.Expressions;
using eCommerceApp.Domain;

namespace eCommerceApp.Application.Contracts.Persistence.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        /// <summary>
        /// Gets single products with category that match predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Product?> FindSingleProductAsync(Expression<Func<Product, bool>> predicate, CancellationToken token);
    }
}