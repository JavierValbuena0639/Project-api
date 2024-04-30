using System.Collections.Generic;
using System.Threading.Tasks;
using Project_api.Model;

namespace Project_api.Services
{
    public interface IProductTypesService
    {
        Task<List<ProductTypes>> GetAllProductTypes();
        Task<ProductTypes?> GetDetailInvoiceById(int detailInvoiceId);
        Task<ProductTypes> CreateDetailInvoice(ProductTypes detailInvoice);
        Task<ProductTypes> UpdateDetailInvoice(ProductTypes detailInvoice);
        Task<bool> DeleteDetailInvoice(int detailInvoiceId);
    }

    public class ProductTypeService : IProductTypesService
    {
        private readonly IProductTypesRepository _productTypesRepository;

        public ProductTypeService(IProductTypesRepository productTypesRepository)
        {
            _productTypesRepository = productTypesRepository;
        }

        public async Task<List<ProductTypes>> GetAllProductTypes()
        {
            return await _productTypesRepository.GetAllProductTypes();
        }

        public async Task<ProductTypes?> GetDetailInvoiceById(int detailInvoiceId)
        {
            return await _productTypesRepository.GetDetailInvoiceById(detailInvoiceId);
        }

        public async Task<ProductTypes> CreateDetailInvoice(ProductTypes detailInvoice)
        {
            return await _productTypesRepository.CreateDetailInvoice(detailInvoice);
        }

        public async Task<ProductTypes> UpdateDetailInvoice(ProductTypes detailInvoice)
        {
            return await _productTypesRepository.UpdateDetailInvoice(detailInvoice);
        }

        public async Task<bool> DeleteDetailInvoice(int detailInvoiceId)
        {
            return await _productTypesRepository.DeleteDetailInvoice(detailInvoiceId);
        }
    }
}
