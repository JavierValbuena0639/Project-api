using Project_api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_api.Services
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserById(int userId);
        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<bool> DeleteUser(int userId);
    }

    public class UserService : IUserService
    {
        private readonly IUsersRepository _userRepository;

        public UserService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<Users> GetUserById(int userId)
        {
            return await _userRepository.GetUserById(userId);
        }

        public async Task<Users> CreateUser(Users user)
        {
            return await _userRepository.CreateUser(user);
        }

        public async Task<Users> UpdateUser(Users user)
        {
            return await _userRepository.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            return await _userRepository.DeleteUser(userId);
        }
    }
}
