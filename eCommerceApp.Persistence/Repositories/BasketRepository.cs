using System.Linq.Expressions;
using eCommerceApp.Application.Contracts.Persistence.Repositories;
using eCommerceApp.Domain;
using eCommerceApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Persistence.Repositories
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        private readonly DbSet<Basket> _baskets;

        public BasketRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _baskets = dbContext.Baskets;
        }

        public async Task<Basket?> RetriveBasketWithItemsAsync(Expression<Func<Basket, bool>> predicate, CancellationToken token)
        {
            return await _baskets.Include(x => x.Items.Where(i => !i.IsRemoved))
                .FirstOrDefaultAsync(predicate, token);
        }
    }
}