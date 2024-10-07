using Stave_Api.Data;
using Stave_Api.Data.Models;
using Stave_Api.Services.Repositories.BaseRepositories;

namespace Stave_Api.Services.Repositories.Products
{
    public class ProductRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductRepository(StaveContext dbContext) : base(dbContext)
        {
        }
    }
}
