using System.Linq.Expressions;
using eCommerceApp.Application.Contracts.Persistence.Repositories;
using eCommerceApp.Domain;
using eCommerceApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DbSet<Product> _products;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Products;
        }

        public Task<Product?> FindSingleProductAsync(Expression<Func<Product, bool>> predicate, CancellationToken token)
        {
            return _products.Include(x=>x.Category).FirstOrDefaultAsync(predicate, token);
        }
    }
}