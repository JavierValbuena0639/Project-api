using Microsoft.AspNetCore.Mvc;
using Project_api.Model;
using Project_api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelIInvoicesRepository = Project_api.Model.IInvoicesRepository;
using ServiceIInvoicesRepository = Project_api.Services.IInvoicesRepository;

namespace Project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ServiceIInvoicesRepository _invoiceService;

        public InvoiceController(ServiceIInvoicesRepository invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Invoices>>> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<Invoices>> GetInvoiceById(int invoiceId)
        {
            var invoice = await _invoiceService.GetInvoiceById(invoiceId);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<ActionResult<Invoices>> CreateInvoice(Invoices invoice)
        {
            var createdInvoice = await _invoiceService.CreateInvoice(invoice);
            return CreatedAtAction(nameof(GetInvoiceById), new { invoiceId = createdInvoice.IdInvoice }, createdInvoice);
        }

        [HttpPut("{invoiceId}")]
        public async Task<IActionResult> UpdateInvoice(int invoiceId, Invoices invoice)
        {
            if (invoiceId != invoice.IdInvoice)
            {
                return BadRequest();
            }

            var updatedInvoice = await _invoiceService.UpdateInvoice(invoice);
            if (updatedInvoice == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice(int invoiceId)
        {
            var result = await _invoiceService.DeleteInvoice(invoiceId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
