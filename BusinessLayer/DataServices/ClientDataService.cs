using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.EntityFramework;

namespace BusinessLayer.DataServices
{
    public class ClientDataService : IClientDataService
    {
        public IEnumerable<Client> GetClients()
        {
            using (DbContext context = new BibliotecaEntities())
            {
                return context.Set<Client>().ToList();
            }
        }

        public void AddClient(Client client)
        {
            using (BibliotecaEntities context = new BibliotecaEntities())
            {
                context.Entry(client).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public Client GetClient(int id)
        {
            using (DbContext context = new BibliotecaEntities())
            {
                return context.Set<Client>().Find(id);
            }
        }

        public void EditClient(Client client)
        {
            using (BibliotecaEntities context = new BibliotecaEntities())
            {
                context.Entry(client).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteClient(int id)
        {
            using (BibliotecaEntities context = new BibliotecaEntities())
            {
                Client client = GetClient(id);
                context.Entry(client).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
