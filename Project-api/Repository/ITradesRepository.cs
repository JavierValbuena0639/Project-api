using Microsoft.EntityFrameworkCore;
using Project_api.Context;
using Project_api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_api.Repository
{
    public interface ITradesRepository
    {
        Task<List<Trades>> GetAllTrades();
        Task<Trades?> GetTradeById(int tradeId);
        Task<Trades> CreateTrade(Trades trade);
        Task<Trades> UpdateTrade(Trades trade);
        Task<bool> DeleteTrade(int tradeId);
    }

    public class TradesRepository : ITradesRepository
    {
        private readonly DbProject _context;

        public TradesRepository(DbProject context)
        {
            _context = context;
        }

        public async Task<List<Trades>> GetAllTrades()
        {
            return await _context.trades.ToListAsync();
        }

        public async Task<Trades?> GetTradeById(int tradeId)
        {
            return await _context.trades.FindAsync(tradeId);
        }

        public async Task<Trades> CreateTrade(Trades trade)
        {
            _context.trades.Add(trade);
            await _context.SaveChangesAsync();
            return trade;
        }

        public async Task<Trades> UpdateTrade(Trades trade)
        {
            _context.Entry(trade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return trade;
        }

        public async Task<bool> DeleteTrade(int tradeId)
        {
            var trade = await _context.trades.FindAsync(tradeId);
            if (trade == null)
            {
                return false;
            }

            _context.trades.Remove(trade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
