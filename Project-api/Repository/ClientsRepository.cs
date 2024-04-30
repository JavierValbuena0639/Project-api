using Project_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_api.Context;

namespace Project_api.Repository
{
    public interface IClientRepository
    {
        Task<List<Clients>> GetAllClients();
        Task<Clients?> GetClientById(int clientId);
        Task<Clients> CreateClient(Clients client);
        Task<Clients> UpdateClient(Clients client);
        Task<bool> DeleteClient(int clientId);
    }

    public class ClientRepository : IClientRepository
    {
        private readonly DbProject _context;

        public ClientRepository(DbProject context)
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
            var existingClient = await _context.clients.FindAsync(client.IdClient);
            if (existingClient == null)
            {
                throw new InvalidOperationException("Client not found.");
            }

            _context.Entry(existingClient).CurrentValues.SetValues(client);
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
