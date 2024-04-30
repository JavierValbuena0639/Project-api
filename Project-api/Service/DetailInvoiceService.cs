using System.Collections.Generic;
using System.Threading.Tasks;
using Project_api.Model;

namespace Project_api.Services
{
    public interface IDetailInvoicesService
    {
        Task<List<DetailInvoices>> GetAllDetailInvoices();
        Task<DetailInvoices?> GetDetailInvoiceById(int detailInvoiceId);
        Task<DetailInvoices> CreateDetailInvoice(DetailInvoices detailInvoice);
        Task<DetailInvoices> UpdateDetailInvoice(DetailInvoices detailInvoice);
        Task<bool> DeleteDetailInvoice(int detailInvoiceId);
    }

    public class DetailInvoiceService : IDetailInvoicesService
    {
        private readonly IDetailInvoicesRepository _detailInvoicesRepository;

        public DetailInvoiceService(IDetailInvoicesRepository detailInvoicesRepository)
        {
            _detailInvoicesRepository = detailInvoicesRepository;
        }

        public async Task<List<DetailInvoices>> GetAllDetailInvoices()
        {
            return await _detailInvoicesRepository.GetAllDetailInvoices();
        }

        public async Task<DetailInvoices?> GetDetailInvoiceById(int detailInvoiceId)
        {
            return await _detailInvoicesRepository.GetDetailInvoiceById(detailInvoiceId);
        }

        public async Task<DetailInvoices> CreateDetailInvoice(DetailInvoices detailInvoice)
        {
            return await _detailInvoicesRepository.CreateDetailInvoice(detailInvoice);
        }

        public async Task<DetailInvoices> UpdateDetailInvoice(DetailInvoices detailInvoice)
        {
            return await _detailInvoicesRepository.UpdateDetailInvoice(detailInvoice);
        }

        public async Task<bool> DeleteDetailInvoice(int detailInvoiceId)
        {
            return await _detailInvoicesRepository.DeleteDetailInvoice(detailInvoiceId);
        }
    }
}
