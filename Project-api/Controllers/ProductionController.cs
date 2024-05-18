using Microsoft.AspNetCore.Mvc;
using Project_api.Model;
using Project_api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly IProductionsService _productionService;

        public ProductionController(IProductionsService productionService)
        {
            _productionService = productionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Productions>>> GetAllProductions()
        {
            var productions = await _productionService.GetAllProductions();
            return Ok(productions);
        }

        [HttpGet("{productionId}")]
        public async Task<ActionResult<Productions>> GetProductionById(int productionId)
        {
            var production = await _productionService.GetProductionById(productionId);
            if (production == null)
            {
                return NotFound();
            }
            return Ok(production);
        }

        [HttpPost]
        public async Task<ActionResult<Productions>> CreateProduction(Productions production)
        {
            var createdProduction = await _productionService.CreateProduction(production);
            return CreatedAtAction(nameof(GetProductionById), new { productionId = createdProduction.IdProduct }, createdProduction);
        }


        [HttpPut("{productionId}")]
        public async Task<IActionResult> UpdateProduction(int productionId, Productions production)
        {
            if (productionId != production.IdProduction)
            {
                return BadRequest();
            }

            var updatedProduction = await _productionService.UpdateProduction(production);
            if (updatedProduction == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{productionId}")]
        public async Task<IActionResult> DeleteProduction(int productionId)
        {
            var result = await _productionService.DeleteProduction(productionId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
