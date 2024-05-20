using Microsoft.EntityFrameworkCore;
using Project_api.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_api.Model
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetAllUsers();
        Task<Users?> GetUserByEmail(string email);
        Task<Users?> GetUserByEmailAndPassword(string email, string password);
        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<bool> DeleteUser(int idUser);
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

        public async Task<Users?> GetUserByEmail(string email)
        {
            return await _context.users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Users?> GetUserByEmailAndPassword(string email, string password)
        {
            return await _context.users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
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

        public async Task<bool> DeleteUser(int idUser)
        {
            var user = await _context.users.FindAsync(idUser);
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
