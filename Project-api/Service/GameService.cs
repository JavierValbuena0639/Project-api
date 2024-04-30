using System.Collections.Generic;
using System.Threading.Tasks;
using Project_api.Model;

namespace Project_api.Services
{
    public interface IGamesService
    {
        Task<List<Games>> GetAllGames();
        Task<Games?> GetGameById(int gameId);
        Task<Games> CreateGame(Games game);
        Task<Games> UpdateGame(Games game);
        Task<bool> DeleteGame(int gameId);
    }

    public class GameService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;

        public GameService(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<List<Games>> GetAllGames()
        {
            return await _gamesRepository.GetAllGames();
        }

        public async Task<Games?> GetGameById(int gameId)
        {
            return await _gamesRepository.GetGameById(gameId);
        }

        public async Task<Games> CreateGame(Games game)
        {
            return await _gamesRepository.CreateGame(game);
        }

        public async Task<Games> UpdateGame(Games game)
        {
            return await _gamesRepository.UpdateGame(game);
        }

        public async Task<bool> DeleteGame(int gameId)
        {
            return await _gamesRepository.DeleteGame(gameId);
        }
    }
}
