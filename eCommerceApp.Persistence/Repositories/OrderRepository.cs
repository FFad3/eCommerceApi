using eCommerceApp.Application.Contracts.Persistence.Repositories;
using eCommerceApp.Domain;
using eCommerceApp.Persistence.Data;

namespace eCommerceApp.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}