using Microsoft.AspNetCore.Mvc;
using Project_api.Model;
using Project_api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener todos los usuarios: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Users>> GetUserById(int userId)
        {
            try
            {
                var user = await _userService.GetUserById(userId);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el usuario con ID {userId}: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(Users user)
        {
            try
            {
                var createdUser = await _userService.CreateUser(user);
                return CreatedAtAction(nameof(GetUserById), new { userId = createdUser.IdUser }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el usuario: {ex.Message}");
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, Users user)
        {
            try
            {
                if (userId != user.IdUser)
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
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el usuario con ID {userId}: {ex.Message}");
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                var result = await _userService.DeleteUser(userId);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el usuario con ID {userId}: {ex.Message}");
            }
        }
    }
}
