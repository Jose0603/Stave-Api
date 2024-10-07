using Stave_Api.Data;
using Stave_Api.Services.Repositories.Products;
using Stave_Api.Services.Repositories.ProductImages;
using System.Threading.Tasks;

namespace Stave_Api.Services.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StaveContext _databaseContext;
        private bool _disposed;

        public UnitOfWork(StaveContext databaseContext)
        {
            _databaseContext = databaseContext;
            ProductsRepository = new ProductRepository(databaseContext);
            ProductImagesRepository = new ProductImagesRepository(databaseContext);

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public IProductsRepository ProductsRepository { get; private set; }
        public IProductImagesRepository ProductImagesRepository { get; private set; }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return _databaseContext.SaveChangesAsync(cancellationToken);
        }
        public Task<int> CommitAsync()
        {
            return _databaseContext.SaveChangesAsync();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _databaseContext.Dispose();
            _disposed = true;
        }
    }
}
