using Microsoft.AspNetCore.Mvc;
using Project_api.Model;
using Project_api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Users>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("login")]
        public async Task<ActionResult<Users>> GetUserByEmailAndPassword([FromQuery] string email, [FromQuery] string password)
        {
            var user = await _userService.GetUserByEmailAndPassword(email, password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(Users user)
        {
            var createdUser = await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserByEmail), new { email = createdUser.Email }, createdUser);
        }

        [HttpPut("{idUser}")]
        public async Task<IActionResult> UpdateUser(int idUser, Users user)
        {
            if (idUser != user.IdUser)
            {
                return BadRequest();
            }

            var updatedUser = await _userService.UpdateUser(user);
            if (updatedUser == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{idUser}")]
        public async Task<IActionResult> DeleteUser(int idUser)
        {
            var result = await _userService.DeleteUser(idUser);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
