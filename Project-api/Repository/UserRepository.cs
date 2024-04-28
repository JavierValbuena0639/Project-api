using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_api.Context;
using Project_api.Model;

namespace Project_api.Repository
{
    public interface IUserRepository
    {
        Task<List<Users>> GetAll();
        Task<Users?> GetUserById(int IdUser);
        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<bool> DeleteUser(int IdUser);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DbProject _context;

        public UserRepository(DbProject context)
        {
            _context = context;
        }

        public async Task<List<Users>> GetAll()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<Users?> GetUserById(int IdUser)
        {
            return await _context.users.FirstOrDefaultAsync(u => u.IdUser == IdUser);
        }

        public async Task<Users> CreateUser(Users user)
        {
            var existingUser = await _context.users.FirstOrDefaultAsync(u => u.Username == user.Username || u.Email == user.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("El usuario ya existe.");
            }

            // Aquí puedes agregar disparadores para la contraseña si es necesario

            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Users> UpdateUser(Users user)
        {
            var existingUser = await _context.users.FirstOrDefaultAsync(u => u.IdUser == user.IdUser);
            if (existingUser == null)
            {
                throw new InvalidOperationException("Usuario no encontrado.");
            }

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int IdUser)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.IdUser == IdUser);
            if (user == null)
            {
                throw new InvalidOperationException("Usuario no encontrado.");
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
