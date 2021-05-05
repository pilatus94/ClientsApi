using Api.Models;
using System.Collections.Generic;

namespace Api.Repository
{
    public interface IClientRepository
    {
        void AddClient(Client client);

        List<Client> GetAllClients();

        Client GetClient(int id);

        void UpdateClient(int id, Client client);

        void DeleteClient(int id);
    }
}