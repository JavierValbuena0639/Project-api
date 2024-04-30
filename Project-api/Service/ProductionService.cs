using System.Collections.Generic;
using System.Threading.Tasks;
using Project_api.Model;

namespace Project_api.Services
{
    public interface IProductionsService
    {
        Task<List<Productions>> GetAllProductions();
        Task<Productions?> GetProductionById(int productionId);
        Task<Productions> CreateProduction(Productions production);
        Task<Productions> UpdateProduction(Productions production);
        Task<bool> DeleteProduction(int productionId);
    }

    public class ProductionService : IProductionsService
    {
        private readonly IProductionsRepository _productionsRepository;

        public ProductionService(IProductionsRepository productionsRepository)
        {
            _productionsRepository = productionsRepository;
        }

        public async Task<List<Productions>> GetAllProductions()
        {
            return await _productionsRepository.GetAllProductions();
        }

        public async Task<Productions?> GetProductionById(int productionId)
        {
            return await _productionsRepository.GetProductionById(productionId);
        }

        public async Task<Productions> CreateProduction(Productions production)
        {
            return await _productionsRepository.CreateProduction(production);
        }

        public async Task<Productions> UpdateProduction(Productions production)
        {
            return await _productionsRepository.UpdateProduction(production);
        }

        public async Task<bool> DeleteProduction(int productionId)
        {
            return await _productionsRepository.DeleteProduction(productionId);
        }
    }
}
