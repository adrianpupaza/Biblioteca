using System.Collections.Generic;
using DataAccess.EntityFramework;

namespace BusinessLayer.DataServices
{
    public interface IClientDataService
    {
        IEnumerable<Client> GetClients();
        void AddClient(Client client);
        Client GetClient(int id);
        void EditClient(Client client);
        void DeleteClient(int id);
    }
}
