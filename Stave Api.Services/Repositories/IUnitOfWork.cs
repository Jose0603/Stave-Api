using Stave_Api.Services.Repositories.Products;
using Stave_Api.Services.Repositories.ProductImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stave_Api.Services.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IProductsRepository ProductsRepository { get; }
        IProductImagesRepository ProductImagesRepository { get; }

        //int Save();
        Task<int> CommitAsync(CancellationToken cancellationToken);
        Task<int> CommitAsync();
    }
}
