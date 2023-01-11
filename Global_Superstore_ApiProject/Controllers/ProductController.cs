using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.ViewModels;
using Services.ServicesForModels;

namespace Global_Superstore_ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductService _productService;



        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts()
        {
            var allProducts = _productService.GetAllProducts();
            return Ok(allProducts);
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet("get-products-by-id/{id}")]
        public IActionResult GetProductsById(int id)
        {
            var products = _productService.GetProductsById(id);
            return Ok(products);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("add-products")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPut("update-product-by-id/{id}")]
        public IActionResult UpdateProductById(int id, [FromBody] ProductVM product)
        {
            var updateProduct = _productService.UpdateProductsById(id, product);
            return Ok(updateProduct);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("delete-products-by-id/{id}")]
        public IActionResult DeleteProductById(int id)
        {
            _productService.DeleteProductById(id);
            return Ok();
        }
    }
}
