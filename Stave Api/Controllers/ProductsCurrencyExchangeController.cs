using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stave_Api.Data.DTOs;
using Stave_Api.Services.Exchange_Service;

namespace Stave_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsCurrencyExchangeController : ControllerBase
    {
        protected readonly ICurrencyFreaksService _service;

        public ProductsCurrencyExchangeController(ICurrencyFreaksService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(List<ProductChange> products)
        {
            var entityList = _service.Exchange(products).Result;
            return Ok(entityList);
        }
    }
}
