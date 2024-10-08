﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stave_Api.Data.DTOs;
using Stave_Api.Services.Services.ProductsServices;

namespace Stave_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entityList = _service.GetAll();
            return Ok(entityList);
        }
        [HttpPost]
        public async Task<IActionResult> Post(List<ProductDTO> list)
        {
            var entityList = _service.BulkCreate(list).Result;
            return Ok(entityList);
        }
    }
}
