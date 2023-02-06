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
        /// Save changes asynchronusly
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<bool> SaveChangesAsync(CancellationToken cancellation);
    }
}