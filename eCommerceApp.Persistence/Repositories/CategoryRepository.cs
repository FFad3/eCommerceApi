using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Domain;
using eCommerceApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerceApp.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly DbSet<Category> _categories;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _categories = dbContext.Categories;
        }

        public Task<Category?> FindSingleWithProductsAsync(Expression<Func<Category, bool>> predicate, CancellationToken token)
        {
            return _categories.Include(x => x.Products.Where(p => !p.IsRemoved))
                                .FirstOrDefaultAsync(predicate, token);
        }
    }
}