using System.Collections.Generic;
using System.Threading.Tasks;
using Project_api.Model;
using Project_api.Repository;

namespace Project_api.Services
{
    public interface IClientsService
    {
        Task<List<Clients>> GetAllClients();
        Task<Clients?> GetClientById(int clientId);
        Task<Clients> CreateClient(Clients client);
        Task<Clients> UpdateClient(Clients client);
        Task<bool> DeleteClient(int clientId);
    }

    public class ClientService : IClientsService
    {
        private readonly IClientsService _clientsRepository;

        public ClientService(IClientsService clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<List<Clients>> GetAllClients()
        {
            return await _clientsRepository.GetAllClients();
        }

        public async Task<Clients?> GetClientById(int clientId)
        {
            return await _clientsRepository.GetClientById(clientId);
        }

        public async Task<Clients> CreateClient(Clients client)
        {
            return await _clientsRepository.CreateClient(client);
        }

        public async Task<Clients> UpdateClient(Clients client)
        {
            return await _clientsRepository.UpdateClient(client);
        }

        public async Task<bool> DeleteClient(int clientId)
        {
            return await _clientsRepository.DeleteClient(clientId);
        }
    }
}
