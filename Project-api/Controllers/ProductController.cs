using Microsoft.AspNetCore.Mvc;
using Project_api.Model;
using Project_api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Products>> GetProductById(int productId)
        {
            var product = await _productService.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Products>> CreateProduct(Products product)
        {
            var createdProduct = await _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { productId = createdProduct.IdProduct }, createdProduct);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, Products product)
        {
            if (productId != product.IdProduct)
            {
                return BadRequest();
            }

            var updatedProduct = await _productService.UpdateProduct(product);
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var result = await _productService.DeleteProduct(productId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
