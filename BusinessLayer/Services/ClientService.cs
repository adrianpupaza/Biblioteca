using System.Collections.Generic;
using BusinessLayer.DataServices;
using BusinessLayer.ViewModels;
using System.Collections;
using DataAccess.EntityFramework;

namespace BusinessLayer.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientDataService clientDataService;

        public ClientService()
        {
            this.clientDataService = new ClientDataService();
        }

        public ListClientViewModel GetClients()
        {
            IEnumerable<Client> clients = clientDataService.GetClients();

            IList<ClientViewModel> clientViewModels = new List<ClientViewModel>();
            foreach (Client client in clients)
            {
                clientViewModels.Add(this.GetClientViewModel(client));
            }

            return new ListClientViewModel
            {
                Clients = clientViewModels
            };
        }

        public void AddClient(ClientViewModel viewModel)
        {
            Client client = new Client
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                CNP = viewModel.Cnp,
                PhoneNumber = viewModel.PhoneNumber
            };

            clientDataService.AddClient(client);
        }

        public ClientViewModel GetClient(int id)
        {
            Client client = clientDataService.GetClient(id);

            ClientViewModel viewModel = GetClientViewModel(client);

            return viewModel;
        }

        private ClientViewModel GetClientViewModel(Client client)
        {
            ClientViewModel clientViewModel = new ClientViewModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Cnp = client.CNP,
                PhoneNumber = client.PhoneNumber
            };

            return clientViewModel;
        }

        public void EditClient(ClientViewModel viewModel)
        {
            Client client = new Client
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                CNP = viewModel.Cnp,
                PhoneNumber = viewModel.PhoneNumber
            };

            clientDataService.EditClient(client);
        }

        public void DeleteClient(int id)
        {
            clientDataService.DeleteClient(id);
        }
    }
}
