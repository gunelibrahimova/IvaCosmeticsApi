using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IvaBeautyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeController : ControllerBase
    {
        private readonly IProductSizeManager _productSizeManager;

        public ProductSizeController(IProductSizeManager productSizeManager)
        {
            _productSizeManager = productSizeManager;
        }

        [HttpGet("getall")]
        public List<ProductSize> GetAll()
        {
            return _productSizeManager.GetAllProductSize();
        }

        [HttpPost("add")]
        public object AddProductSize(ProductSize productSize)
        {
            _productSizeManager.Add(productSize);
            return Ok("Size added");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProductSize(ProductSize productSize, int id)
        {
            _productSizeManager.Update(productSize, id);
            return Ok(new { status = 200, message = "Size yenilendi." });
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteProductSize(ProductSize productSize, int id)
        {
            _productSizeManager.Remove(productSize, id);
            return Ok("Melumat ugurla silindi.");
        }
    }
}
