using Microsoft.AspNetCore.Mvc;
using Project_api.Model;
using Project_api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypesService _productTypeService;

        public ProductTypeController(IProductTypesService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductTypes>>> GetAllProductTypes()
        {
            var productTypes = await _productTypeService.GetAllProductTypes();
            return Ok(productTypes);
        }

        [HttpGet("{detailInvoiceId}")]
        public async Task<ActionResult<ProductTypes>> GetProductTypeById(int detailInvoiceId)
        {
            var productType = await _productTypeService.GetDetailInvoiceById(detailInvoiceId);
            if (productType == null)
            {
                return NotFound();
            }
            return Ok(productType);
        }

        [HttpPost]
        public async Task<ActionResult<ProductTypes>> CreateProductType(ProductTypes productType)
        {
            var createdProductType = await _productTypeService.CreateDetailInvoice(productType);
            return CreatedAtAction(nameof(GetProductTypeById), new { detailInvoiceId = createdProductType.IdProductType }, createdProductType);
        }

        [HttpPut("{detailInvoiceId}")]
        public async Task<IActionResult> UpdateProductType(int detailInvoiceId, ProductTypes productType)
        {
            if (detailInvoiceId != productType.IdProductType)
            {
                return BadRequest();
            }

            var updatedProductType = await _productTypeService.UpdateDetailInvoice(productType);
            if (updatedProductType == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{detailInvoiceId}")]
        public async Task<IActionResult> DeleteProductType(int detailInvoiceId)
        {
            var result = await _productTypeService.DeleteDetailInvoice(detailInvoiceId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
