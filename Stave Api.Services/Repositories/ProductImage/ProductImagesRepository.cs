using Stave_Api.Data;
using Stave_Api.Data.Models;
using Stave_Api.Services.Repositories.BaseRepositories;

namespace Stave_Api.Services.Repositories.ProductImages
{
    public class ProductImagesRepository : GenericRepository<ProductImage>, IProductImagesRepository
    {
        public ProductImagesRepository(StaveContext dbContext) : base(dbContext)
        {
        }
    }
}
