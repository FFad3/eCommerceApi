using eCommerceApp.Application.Contracts.Persistence.Repositories;
using eCommerceApp.Domain;
using eCommerceApp.Persistence.Data;

namespace eCommerceApp.Persistence.Repositories
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}