using Stave_Api.Data.DTOs;
using Stave_Api.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stave_Api.Services.Services.ProductsServices
{
    public interface IProductService
    {
        Task<CustomHttpResponse> GetAll();
        Task<CustomHttpResponse> GetAllWithSearchParam(string SearchParam);
        Task<CustomHttpResponse> GetAllWithPagination(int PageNumber);
        Task<CustomHttpResponse> GetAllWithPaginationAndSearchParam(int PageNumber, string SearchParam);
        Task<CustomHttpResponse> GetById(int Id);
        Task<CustomHttpResponse> Create(ProductDTO newItem);
        Task<CustomHttpResponse> BulkCreate(List<ProductDTO> itemList);
        Task<CustomHttpResponse> Update(ProductDTO toEdit);
    }
}
