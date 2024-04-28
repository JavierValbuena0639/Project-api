using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Project_api.Context;

namespace Project_api.Model
{
    public interface IProductionsRepository
    {
        Task<List<Productions>> GetAllProductions();
        Task<Productions?> GetProductionById(int productionId);
        Task<Productions> CreateProduction(Productions production);
        Task<Productions> UpdateProduction(Productions production);
        Task<bool> DeleteProduction(int productionId);
    }


    public class ProductionsRepository : IProductionsRepository
    {
        private readonly DbProject _context;

        public ProductionsRepository(DbProject context)
        {
            _context = context;
        }

        public async Task<List<Productions>> GetAllProductions()
        {
            return await _context.productions.ToListAsync();
        }

        public async Task<Productions?> GetProductionById(int productionId)
        {
            return await _context.productions.FindAsync(productionId);
        }

        public async Task<Productions> CreateProduction(Productions production)
        {
            _context.productions.Add(production);
            await _context.SaveChangesAsync();
            return production;
        }

        public async Task<Productions> UpdateProduction(Productions production)
        {
            _context.Entry(production).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return production;
        }

        public async Task<bool> DeleteProduction(int productionId)
        {
            var production = await _context.productions.FindAsync(productionId);
            if (production == null)
            {
                return false;
            }

            _context.productions.Remove(production);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
