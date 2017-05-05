using BusinessLayer.ViewModels;

namespace BusinessLayer.Services
{
    public interface IClientService
    {
        ListClientViewModel GetClients();
        void AddClient(ClientViewModel viewModel);
        ClientViewModel GetClient(int id);
        void EditClient(ClientViewModel viewModel);
        void DeleteClient(int id);
    }
}
