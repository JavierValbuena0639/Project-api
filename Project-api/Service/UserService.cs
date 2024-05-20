using Project_api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_api.Services
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users?> GetUserByEmail(string email);
        Task<Users?> GetUserByEmailAndPassword(string email, string password);
        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<bool> DeleteUser(int idUser);
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

        public async Task<Users?> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<Users?> GetUserByEmailAndPassword(string email, string password)
        {
            return await _userRepository.GetUserByEmailAndPassword(email, password);
        }

        public async Task<Users> CreateUser(Users user)
        {
            return await _userRepository.CreateUser(user);
        }

        public async Task<Users> UpdateUser(Users user)
        {
            return await _userRepository.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(int idUser)
        {
            return await _userRepository.DeleteUser(idUser);
        }
    }
}
