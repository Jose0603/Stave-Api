using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stave_Api.Data.DTOs;
using Stave_Api.Data.Models;
using Stave_Api.Services.Repositories;
using Stave_Api.Services.Shared;
using System.Net;
using System.Security.Claims;

namespace Stave_Api.Services.Services.ProductsServices
{
    public class ProductService : IProductService
    {
        protected readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomHttpResponse> BulkCreate(List<ProductDTO> itemList)
        {
            CustomHttpResponse response = new CustomHttpResponse();

            try
            {
                // Map DTOs to entities
                var createProducts = itemList.Select(_mapper.Map<Product>).ToList();

                // Ensure there are products to create
                if (createProducts != null && createProducts.Count > 0)
                {
                    // Insert products into the database (using your ORM or data access)
                    _unitOfWork.ProductsRepository.AddRange(createProducts); // Assuming Entity Framework is being used

                    // Save changes to the database
                     _unitOfWork.ProductsRepository.SaveChanges();

                    // Return the created products as part of the response (optional)
                    response.Data = createProducts;
                }
                else
                {
                    response.Data = new List<object>(); // Return an empty list if no products were created
                }

                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Handle the error and set the response accordingly
                ErrorHandler.HandleErrorWithResponse(
                    ex,
                    response,
                    "An error occurred while processing the request.",
                    HttpStatusCode.Conflict
                );
            }

            return response; // Return the response object
        }

        public Task<CustomHttpResponse> Create(ProductDTO newItem)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomHttpResponse> GetAll()
        {
            CustomHttpResponse response = new CustomHttpResponse();
            try
            {
                List<Product> listOfEntites = _unitOfWork.ProductsRepository.GetAllInclude("ProductImages").ToList();
                if (listOfEntites != null && listOfEntites.Count > 0 || listOfEntites.Count == 0)
                {
                    if (listOfEntites.Count > 0)
                    {
                        response.Data = listOfEntites.Select(_mapper.Map<ProductDTO>).ToList();
                    }
                    else if (listOfEntites.Count == 0)
                    {
                        response.Data = new List<object>();
                    }
                }
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                ErrorHandler.HandleErrorWithResponse(
                    ex,
                    response,
                    "Ha ocurrido un error en la base de datos.",
                    HttpStatusCode.Conflict
                );
            }
            return response;
        }

        public Task<CustomHttpResponse> GetAllWithPagination(int PageNumber)
        {
            throw new NotImplementedException();
        }

        public Task<CustomHttpResponse> GetAllWithPaginationAndSearchParam(int PageNumber, string SearchParam)
        {
            throw new NotImplementedException();
        }

        public Task<CustomHttpResponse> GetAllWithSearchParam(string SearchParam)
        {
            throw new NotImplementedException();
        }

        public Task<CustomHttpResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomHttpResponse> Update(ProductDTO toEdit)
        {
            throw new NotImplementedException();
        }
    }
}
