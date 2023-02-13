using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Domain;
using eCommerceApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerceApp.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly ApplicationDbContext _DbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public IQueryable<TEntity> AsQuerable() => _DbContext.Set<TEntity>().AsQueryable();

        public Task<int> CountAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token)
        {
            return _DbContext.Set<TEntity>().CountAsync(predicate, token);
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken token)
        {
            await _DbContext.AddAsync(entity, token);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token)
        {
            return await _DbContext.Set<TEntity>().Where(predicate).ToListAsync(token);
        }

        public Task<TEntity?> FindSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token)
        {
            return _DbContext.Set<TEntity>().FirstOrDefaultAsync(predicate, token);
        }

        public Task<bool> IsExist(Expression<Func<TEntity, bool>> predicate, CancellationToken token)
        {
            return _DbContext.Set<TEntity>().AnyAsync(predicate, token);
        }

        public void Remove(TEntity entity)
        {
            _DbContext.Entry(entity).State = EntityState.Deleted;
            _DbContext.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _DbContext.Entry(entity).State = EntityState.Modified;
            _DbContext.Set<TEntity>().Update(entity);
        }
    }
}