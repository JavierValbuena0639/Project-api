using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Project_api.Context;
using static Project_api.Model.UsersRepository;

namespace Project_api.Model
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetAllUsers();
        Task<Users?> GetUserById(int userId);
        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<bool> DeleteUser(int userId);
    }
    public class UsersRepository : IUsersRepository
    {
        private readonly DbProject _context;

        public UsersRepository(DbProject context)
        {
            _context = context;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<Users?> GetUserById(int userId)
        {
            return await _context.users.FindAsync(userId);
        }

        public async Task<Users> CreateUser(Users user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Users> UpdateUser(Users user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _context.users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
