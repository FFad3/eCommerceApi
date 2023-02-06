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
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> SaveChangesAsync(CancellationToken token);
    }
}