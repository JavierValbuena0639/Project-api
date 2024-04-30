using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Project_api.Context;

namespace Project_api.Model
{
    public interface IInvoicesRepository
    {
        Task<List<Invoices>> GetAllInvoices();
        Task<Invoices?> GetInvoiceById(int invoiceId);
        Task<Invoices> CreateInvoice(Invoices invoice);
        Task<Invoices> UpdateInvoice(Invoices invoice);
        Task<bool> DeleteInvoice(int invoiceId);
    }

        public class InvoicesRepository : IInvoicesRepository
        {
            private readonly DbProject _context;

            public InvoicesRepository(DbProject context)
            {
                _context = context;
            }

            public async Task<List<Invoices>> GetAllInvoices()
            {
                return await _context.invoices.ToListAsync();
            }

            public async Task<Invoices?> GetInvoiceById(int invoiceId)
            {
                return await _context.invoices.FindAsync(invoiceId);
            }

            public async Task<Invoices> CreateInvoice(Invoices invoice)
            {
                _context.invoices.Add(invoice);
                await _context.SaveChangesAsync();
                return invoice;
            }

            public async Task<Invoices> UpdateInvoice(Invoices invoice)
            {
                _context.Entry(invoice).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return invoice;
            }

            public async Task<bool> DeleteInvoice(int invoiceId)
            {
                var invoice = await _context.invoices.FindAsync(invoiceId);
                if (invoice == null)
                {
                    return false;
                }

                _context.invoices.Remove(invoice);
                await _context.SaveChangesAsync();
                return true;
            }
        }

    }

