using Project_api.Model; // Assuming models are in a separate folder named "Model"
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_api.Context; // Assuming context is in a separate folder named "Context"

namespace Project_api.Repository
{
    public interface IClientsRepository
    {
        Task<List<Clients>> GetAllClients();
        Task<Clients?> GetClientById(int clientId);
        Task<Clients> CreateClient(Clients client);
        Task<Clients> UpdateClient(Clients client);
        Task<bool> DeleteClient(int clientId);
    }

    public class ClientsRepository : IClientsRepository
    {
        private readonly DbProject _context;

        public ClientsRepository(DbProject context)
        {
            _context = context;
        }

        public async Task<List<Clients>> GetAllClients()
        {
            return await _context.clients.ToListAsync();
        }

        public async Task<Clients?> GetClientById(int clientId)
        {
            return await _context.clients.FindAsync(clientId);
        }

        public async Task<Clients> CreateClient(Clients client)
        {
            _context.clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Clients> UpdateClient(Clients client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<bool> DeleteClient(int clientId)
        {
            var client = await _context.clients.FindAsync(clientId);
            if (client == null)
            {
                return false;
            }

            _context.clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
