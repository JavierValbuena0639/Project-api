using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Project_api.Context;

namespace Project_api.Model
{
    public interface IProductTypesRepository
    {
        Task<List<ProductTypes>> GetAllProductTypes();
        Task<ProductTypes?> GetDetailInvoiceById(int detailInvoiceId);
        Task<ProductTypes> CreateDetailInvoice(ProductTypes detailInvoice);
        Task<ProductTypes> UpdateDetailInvoice(ProductTypes detailInvoice);
        Task<bool> DeleteDetailInvoice(int detailInvoiceId);
    }


    public class ProductTypesRepository : IProductTypesRepository
        {
            private readonly DbProject _context;

            public ProductTypesRepository(DbProject context)
            {
                _context = context;
            }

            public async Task<List<ProductTypes>> GetAllProductTypes()
            {
                return await _context.productTypes.ToListAsync();
            }

            public async Task<ProductTypes?> GetDetailInvoiceById(int detailInvoiceId)
            {
                return await _context.productTypes.FindAsync(detailInvoiceId);
            }

            public async Task<ProductTypes> CreateDetailInvoice(ProductTypes detailInvoice)
            {
                _context.productTypes.Add(detailInvoice);
                await _context.SaveChangesAsync();
                return detailInvoice;
            }

            public async Task<ProductTypes> UpdateDetailInvoice(ProductTypes detailInvoice)
            {
                _context.Entry(detailInvoice).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return detailInvoice;
            }

            public async Task<bool> DeleteDetailInvoice(int detailInvoiceId)
            {
                var detailInvoice = await _context.productTypes.FindAsync(detailInvoiceId);
                if (detailInvoice == null)
                {
                    return false;
                }

                _context.productTypes.Remove(detailInvoice);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }

