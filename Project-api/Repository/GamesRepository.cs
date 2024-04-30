using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Project_api.Context;

namespace Project_api.Model
{
    public interface IGamesRepository
    {
        Task<List<Games>> GetAllGames();
        Task<Games?> GetGameById(int gameId);
        Task<Games> CreateGame(Games game);
        Task<Games> UpdateGame(Games game);
        Task<bool> DeleteGame(int gameId);
    }


            public class GamesRepository : IGamesRepository
            {
            private readonly DbProject _context;

            public GamesRepository(DbProject context)
            {
                _context = context;
            }

            public async Task<List<Games>> GetAllGames()
            {
                return await _context.games.ToListAsync();
            }

            public async Task<Games?> GetGameById(int gameId)
            {
                return await _context.games.FindAsync(gameId);
            }

            public async Task<Games> CreateGame(Games game)
            {
                _context.games.Add(game);
                await _context.SaveChangesAsync();
                return game;
            }

            public async Task<Games> UpdateGame(Games game)
            {
                _context.Entry(game).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return game;
            }

            public async Task<bool> DeleteGame(int gameId)
            {
                var game = await _context.games.FindAsync(gameId);
                if (game == null)
                {
                    return false;
                }

                _context.games.Remove(game);
                await _context.SaveChangesAsync();
                return true;
                }
            }

    }


