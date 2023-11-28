using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainWell___BACKEND.Dtos.Diet;
using TrainWell___BACKEND.Models.Diet;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Services.Interfaces;

namespace TrainWell___BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult<Product>> AddProduct(ProductDto productDto)
        {
            var newProduct = await _productService.AddProductAsync(productDto);

            if (newProduct == null) return BadRequest("Błąd podczas dodawania produktu");
            return Ok(newProduct);
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            await _productService.DeleteProductAsync(productId);
            return Ok(new { message = "Produkt został usunięty" });
        }

        [HttpGet("GetProductById/{productId}")]
        public async Task<ActionResult<Product>> GetProductById(int productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null)
                return NotFound("Produkt o podanym ID nie istnieje");

            return Ok(product);
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products.ToList());
        }
    }
}
