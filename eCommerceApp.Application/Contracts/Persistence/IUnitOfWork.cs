using eCommerceApp.Application.Contracts.Persistence.Repositories;

namespace eCommerceApp.Application.Contracts.Persistence
{
    /// <summary>
    /// UnitOfWork for menage repositories
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets CategoryRepository
        /// </summary>
        ICategoryRepository Category { get; }

        /// <summary>
        /// Gets ProductRepository
        /// </summary>
        IProductRepository Product { get; }

        /// <summary>
        /// Gets BasketRepository
        /// </summary>
        IBasketRepository Basket { get; }

        /// <summary>
        /// Gets OrderRepository
        /// </summary>
        IOrderRepository Order { get; }

        /// <summary>
        /// Save changes asynchronusly
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> SaveChangesAsync(CancellationToken token);
    }
}