using eCommerceApp.Application.Contracts.Persistence.Repositories;
using eCommerceApp.Domain;
using eCommerceApp.Persistence.Data;

namespace eCommerceApp.Persistence.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}