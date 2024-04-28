using Microsoft.EntityFrameworkCore;
using Project_api.Context;
using Project_api.Model;

public interface DetailInvoicesRepository
{
    Task<List<DetailInvoices>> GetAllDetailInvoices();
    Task<DetailInvoices?> GetDetailInvoiceById(int detailInvoiceId);
    Task<DetailInvoices> CreateDetailInvoice(DetailInvoices detailInvoice);
    Task<DetailInvoices> UpdateDetailInvoice(DetailInvoices detailInvoice);
    Task<bool> DeleteDetailInvoice(int detailInvoiceId);
}

public class DetailInvoicesRepository : DetailInvoicesRepository
{
    private readonly DbProject _context;

    public DetailInvoicesRepository(DbProject context)
    {
        _context = context;
    }

    public async Task<List<DetailInvoices>> GetAllDetailInvoices()
    {
        return await _context.detailInvoices.ToListAsync();
    }

    public async Task<DetailInvoices?> GetDetailInvoiceById(int detailInvoiceId)
    {
        return await _context.detailInvoices.FindAsync(detailInvoiceId);
    }

    public async Task<DetailInvoices> CreateDetailInvoice(DetailInvoices detailInvoice)
    {
        _context.detailInvoices.Add(detailInvoice);
        await _context.SaveChangesAsync();
        return detailInvoice;
    }

    public async Task<DetailInvoices> UpdateDetailInvoice(DetailInvoices detailInvoice)
    {
        _context.Entry(detailInvoice).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return detailInvoice;
    }

    public async Task<bool> DeleteDetailInvoice(int detailInvoiceId)
    {
        var detailInvoice = await _context.detailInvoices.FindAsync(detailInvoiceId);
        if (detailInvoice == null)
        {
            return false;
        }

        _context.detailInvoices.Remove(detailInvoice);
        await _context.SaveChangesAsync();
        return true;
    }
}
