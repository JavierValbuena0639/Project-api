using Project_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_api.Context;

namespace Project_api.Repository
{
    public interface IItemsRepository
    {
        Task<List<Product>> GetAllItems();
        Task<Product?> GetItemById(int itemId);
        Task<Product> CreateItem(Product item);
        Task<Product> UpdateItem(Product item);
        Task<bool> DeleteItem(int itemId);
    }

    public class ItemsRepository : IItemsRepository
    {
        private readonly DbProject _context;

        public ItemsRepository(DbProject context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllItems()
        {
            return await _context.items.ToListAsync();
        }

        public async Task<Product?> GetItemById(int itemId)
        {
            return await _context.items.FindAsync(itemId);
        }

        public async Task<Product> CreateItem(Product item)
        {
            _context.items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Product> UpdateItem(Product item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteItem(int itemId)
        {
            var item = await _context.items.FindAsync(itemId);
            if (item == null)
            {
                return false;
            }

            _context.items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
