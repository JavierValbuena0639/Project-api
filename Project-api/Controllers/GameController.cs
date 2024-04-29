using Microsoft.AspNetCore.Mvc;
using Project_api.Model;
using Project_api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelIGamesRepository = Project_api.Model.IGamesRepository;
using ServiceIGamesRepository = Project_api.Services.IGamesRepository;

namespace Project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ServiceIGamesRepository _gameService;

        public GameController(ServiceIGamesRepository gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Games>>> GetAllGames()
        {
            var games = await _gameService.GetAllGames();
            return Ok(games);
        }

        [HttpGet("{gameId}")]
        public async Task<ActionResult<Games>> GetGameById(int gameId)
        {
            var game = await _gameService.GetGameById(gameId);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Games>> CreateGame(Games game)
        {
            var createdGame = await _gameService.CreateGame(game);
            return CreatedAtAction(nameof(GetGameById), new { gameId = createdGame.IdGame }, createdGame);
        }

        [HttpPut("{gameId}")]
        public async Task<IActionResult> UpdateGame(int gameId, Games game)
        {
            if (gameId != game.IdGame)
            {
                return BadRequest();
            }

            var updatedGame = await _gameService.UpdateGame(game);
            if (updatedGame == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{gameId}")]
        public async Task<IActionResult> DeleteGame(int gameId)
        {
            var result = await _gameService.DeleteGame(gameId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
