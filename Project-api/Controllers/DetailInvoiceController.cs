using Microsoft.AspNetCore.Mvc;
using Project_api.Model;
using Project_api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailInvoiceController : ControllerBase
    {
        private readonly DetailInvoicesRepository _detailInvoiceService;

        public DetailInvoiceController(DetailInvoicesRepository detailInvoiceService)
        {
            _detailInvoiceService = detailInvoiceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetailInvoices>>> GetAllDetailInvoices()
        {
            var detailInvoices = await _detailInvoiceService.GetAllDetailInvoices();
            return Ok(detailInvoices);
        }

        [HttpGet("{detailInvoiceId}")]
        public async Task<ActionResult<DetailInvoices>> GetDetailInvoiceById(int detailInvoiceId)
        {
            var detailInvoice = await _detailInvoiceService.GetDetailInvoiceById(detailInvoiceId);
            if (detailInvoice == null)
            {
                return NotFound();
            }
            return Ok(detailInvoice);
        }

        [HttpPost]
        public async Task<ActionResult<DetailInvoices>> CreateDetailInvoice(DetailInvoices detailInvoice)
        {
            var createdDetailInvoice = await _detailInvoiceService.CreateDetailInvoice(detailInvoice);
            return CreatedAtAction(nameof(GetDetailInvoiceById), new { detailInvoiceId = createdDetailInvoice.IdInvoice }, createdDetailInvoice);
        }

        [HttpPut("{detailInvoiceId}")]
        public async Task<IActionResult> UpdateDetailInvoice(int detailInvoiceId, DetailInvoices detailInvoice)
        {
            if (detailInvoiceId != detailInvoice.IdInvoice)
            {
                return BadRequest();
            }

            var updatedDetailInvoice = await _detailInvoiceService.UpdateDetailInvoice(detailInvoice);
            if (updatedDetailInvoice == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{detailInvoiceId}")]
        public async Task<IActionResult> DeleteDetailInvoice(int detailInvoiceId)
        {
            var result = await _detailInvoiceService.DeleteDetailInvoice(detailInvoiceId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
