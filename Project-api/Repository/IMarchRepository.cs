using Project_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_api.Context;

namespace Project_api.Repository
{
    public interface IMatchRepository
    {
        Task<List<ProductType>> GetAllMatches();
        Task<ProductType?> GetMatchById(int matchId);
        Task<ProductType> CreateMatch(ProductType match);
        Task<ProductType> UpdateMatch(ProductType match);
        Task<bool> DeleteMatch(int matchId);
    }

    public class MatchRepository : IMatchRepository
    {
        private readonly DbProject _context;

        public MatchRepository(DbProject context)
        {
            _context = context;
        }

        public async Task<List<ProductType>> GetAllMatches()
        {
            return await _context.matchs.ToListAsync();
        }

        public async Task<ProductType?> GetMatchById(int matchId)
        {
            return await _context.matchs.FindAsync(matchId);
        }

        public async Task<ProductType> CreateMatch(ProductType match)
        {
            _context.matchs.Add(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task<ProductType> UpdateMatch(ProductType match)
        {
            _context.Entry(match).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task<bool> DeleteMatch(int matchId)
        {
            var match = await _context.matchs.FindAsync(matchId);
            if (match == null)
            {
                return false;
            }

            _context.matchs.Remove(match);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
