using System.Collections.Generic;
using System.Threading.Tasks;
using Project_api.Model;

namespace Project_api.Services
{
    public interface IStoresRepository
    {
        Task<List<Stores>> GetAllStores();
        Task<Stores?> GetStoreById(int storeId);
        Task<Stores> CreateStore(Stores store);
        Task<Stores> UpdateStore(Stores store);
        Task<bool> DeleteStore(int storeId);
    }

    public class StoreService : IStoresRepository
    {
        private readonly IStoresRepository _storesRepository;

        public StoreService(IStoresRepository storesRepository)
        {
            _storesRepository = storesRepository;
        }

        public async Task<List<Stores>> GetAllStores()
        {
            return await _storesRepository.GetAllStores();
        }

        public async Task<Stores?> GetStoreById(int storeId)
        {
            return await _storesRepository.GetStoreById(storeId);
        }

        public async Task<Stores> CreateStore(Stores store)
        {
            return await _storesRepository.CreateStore(store);
        }

        public async Task<Stores> UpdateStore(Stores store)
        {
            return await _storesRepository.UpdateStore(store);
        }

        public async Task<bool> DeleteStore(int storeId)
        {
            return await _storesRepository.DeleteStore(storeId);
        }
    }
}
