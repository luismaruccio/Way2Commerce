using Microsoft.AspNetCore.Mvc;
using Way2Commerce.Data.Models.DTOs;
using Way2Commerce.Domain.Services;

namespace Way2Commerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Insert(InsertProductDto product)
        {
            var result = await _service.Insert(product);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewProductDto>>> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateProductDto product)
            => Ok(await _service.Update(product));
            
    }
}
