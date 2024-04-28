using Project_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_api.Context;

namespace Project_api.Repository
{
    public interface ICorpsRepository
    {
        Task<List<Store>> GetAllCorps();
        Task<Store?> GetCorpById(int corpId);
        Task<Store> CreateCorp(Store corp);
        Task<Store> UpdateCorp(Store corp);
        Task<bool> DeleteCorp(int corpId);
    }

    public class CorpsRepository : ICorpsRepository
    {
        private readonly DbProject _context;

        public CorpsRepository(DbProject context)
        {
            _context = context;
        }

        public async Task<List<Store>> GetAllCorps()
        {
            return await _context.corps.ToListAsync();
        }

        public async Task<Store?> GetCorpById(int corpId)
        {
            return await _context.corps.FindAsync(corpId);
        }

        public async Task<Store> CreateCorp(Store corp)
        {
            _context.corps.Add(corp);
            await _context.SaveChangesAsync();
            return corp;
        }

        public async Task<Store> UpdateCorp(Store corp)
        {
            _context.Entry(corp).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return corp;
        }

        public async Task<bool> DeleteCorp(int corpId)
        {
            var corp = await _context.corps.FindAsync(corpId);
            if (corp == null)
            {
                return false;
            }

            _context.corps.Remove(corp);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
