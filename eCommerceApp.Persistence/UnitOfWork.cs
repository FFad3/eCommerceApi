using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Application.Contracts.Persistence.Repositories;
using eCommerceApp.Persistence.Data;
using eCommerceApp.Persistence.Repositories;

namespace eCommerceApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly ApplicationDbContext _dbContext;

        #region Repositories

        private ICategoryRepository? _categoryRepository;
        private IProductRepository? _productRepository;
        private IBasketRepository? _basketRepository;
        private IOrderRepository? _orderRepository;
        private IBasketItemRepository? _basketItemRepository;

        #endregion Repositories

        public ICategoryRepository Category => _categoryRepository ??= new CategoryRepository(_dbContext);

        public IProductRepository Product => _productRepository ??= new ProductRepository(_dbContext);

        public IBasketRepository Basket => _basketRepository ??= new BasketRepository(_dbContext);

        public IOrderRepository Order => _orderRepository ??= new OrderRepository(_dbContext);

        public IBasketItemRepository BasketItem => _basketItemRepository ??= new BasketItemRepository(_dbContext);

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                _dbContext.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken token)
        {
            //Mb return int to compare modified data count
            return await _dbContext.SaveChangesAsync(token) > 0;
        }
    }
}