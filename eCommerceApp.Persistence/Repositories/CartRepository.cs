using System.Linq.Expressions;
using eCommerceApp.Application.Contracts.Persistence.Repositories;
using eCommerceApp.Domain;
using eCommerceApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Persistence.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly DbSet<Cart> _carts;

        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _carts = dbContext.Carts;
        }

        public async Task<Cart?> RetriveCartWithItemsAsync(Expression<Func<Cart, bool>> predicate, CancellationToken token)
        {
            return await _carts.Include(x => x.Items.Where(i => !i.IsRemoved))
                .FirstOrDefaultAsync(predicate, token);
        }
    }
}