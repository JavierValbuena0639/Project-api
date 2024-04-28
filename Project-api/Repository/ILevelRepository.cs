using Project_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_api.Context;

namespace Project_api.Repository
{
    public interface ILevelRepository
    {
        Task<List<Clients>> GetAllLevels();
        Task<Clients?> GetLevelById(int levelId);
        Task<Clients> CreateLevel(Clients level);
        Task<Clients> UpdateLevel(Clients level);
        Task<bool> DeleteLevel(int levelId);
    }

    public class LevelRepository : ILevelRepository
    {
        private readonly DbProject _context;

        public LevelRepository(DbProject context)
        {
            _context = context;
        }

        public async Task<List<Clients>> GetAllLevels()
        {
            return await _context.levels.ToListAsync();
        }

        public async Task<Clients?> GetLevelById(int levelId)
        {
            return await _context.levels.FindAsync(levelId);
        }

        public async Task<Clients> CreateLevel(Clients level)
        {
            _context.levels.Add(level);
            await _context.SaveChangesAsync();
            return level;
        }

        public async Task<Clients> UpdateLevel(Clients level)
        {
            _context.Entry(level).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return level;
        }

        public async Task<bool> DeleteLevel(int levelId)
        {
            var level = await _context.levels.FindAsync(levelId);
            if (level == null)
            {
                return false;
            }

            _context.levels.Remove(level);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
