using System.Collections.Generic;
using System.Threading.Tasks;
using Project_api.Model;

namespace Project_api.Services
{
    public interface IInvoicesService
    {
        Task<List<Invoices>> GetAllInvoices();
        Task<Invoices?> GetInvoiceById(int invoiceId);
        Task<Invoices> CreateInvoice(Invoices invoice);
        Task<Invoices> UpdateInvoice(Invoices invoice);
        Task<bool> DeleteInvoice(int invoiceId);
    }

    public class InvoiceService : IInvoicesService
    {
        private readonly IInvoicesRepository _invoicesRepository;

        public InvoiceService(IInvoicesRepository invoicesRepository)
        {
            _invoicesRepository = invoicesRepository;
        }

        public async Task<List<Invoices>> GetAllInvoices()
        {
            return await _invoicesRepository.GetAllInvoices();
        }

        public async Task<Invoices?> GetInvoiceById(int invoiceId)
        {
            return await _invoicesRepository.GetInvoiceById(invoiceId);
        }

        public async Task<Invoices> CreateInvoice(Invoices invoice)
        {
            return await _invoicesRepository.CreateInvoice(invoice);
        }

        public async Task<Invoices> UpdateInvoice(Invoices invoice)
        {
            return await _invoicesRepository.UpdateInvoice(invoice);
        }

        public async Task<bool> DeleteInvoice(int invoiceId)
        {
            return await _invoicesRepository.DeleteInvoice(invoiceId);
        }
    }
}
