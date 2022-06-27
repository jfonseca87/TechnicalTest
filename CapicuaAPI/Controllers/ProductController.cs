using CapicuaAPI.Model;
using CapicuaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapicuaAPI.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int productId)
        {
            try
            {
                Product product = await _productService.GetProductByIdAsync(productId);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "An error ocurred getting a product");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProductAsync(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newProduct = await _productService.AddNewProduct(product);
                return Ok(newProduct);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "An error ocurred adding a product");
            }
        }

        [HttpPut("{productId:int}")]
        public async Task<IActionResult> UpdateProductAsync(int productId, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bool result = await _productService.UpdateProductAsync(productId, product);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "An error ocurred updating a product");
            }
        }

        [HttpDelete("{productId:int}")]
        public async Task<IActionResult> DeleteProductAsync(int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bool result = await _productService.DeleteProductAsync(productId);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "An error ocurred updating a product");
            }
        }
    }
}
