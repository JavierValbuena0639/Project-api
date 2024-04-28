using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Project_api.Context;

namespace Project_api.Model
{
    public interface IStoresRepository
    {
        Task<List<Stores>> GetAllStores();
        Task<Stores?> GetStoreById(int storeId);
        Task<Stores> CreateStore(Stores store);
        Task<Stores> UpdateStore(Stores store);
        Task<bool> DeleteStore(int storeId);
    }

    public class StoresRepository
    {

        private readonly DbProject _context;

        public StoresRepository(DbProject context)
        {
            _context = context;
        }

        public async Task<List<Stores>> GetAllStores()
        {
            return await _context.stores.ToListAsync();
        }

        public async Task<Stores?> GetStoreById(int storeId)
        {
            return await _context.stores.FindAsync(storeId);
        }

        public async Task<Stores> CreateStore(Stores store)
        {
            _context.stores.Add(store);
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task<Stores> UpdateStore(Stores store)
        {
            _context.Entry(store).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task<bool> DeleteStore(int storeId)
        {
            var store = await _context.stores.FindAsync(storeId);
            if (store == null)
            {
                return false;
            }

            _context.stores.Remove(store);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


