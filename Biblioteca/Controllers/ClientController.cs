using System.Web.Mvc;
using BusinessLayer.Services;
using BusinessLayer.ViewModels;

namespace Biblioteca.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService clientService;

        public ClientController()
        {
            clientService = new ClientService();
        }

        // GET: Client
        public ActionResult Index()
        {
            ListClientViewModel viewModel = clientService.GetClients();

            return View(viewModel);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            ClientViewModel viewModel = new ClientViewModel();

            return View(viewModel);
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientViewModel viewModel)
        {
            try
            {
                clientService.AddClient(viewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {

            ClientViewModel viewModel = clientService.GetClient(id);

            return View(viewModel);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ClientViewModel viewModel)
        {
            try
            {
                clientService.EditClient(viewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            ClientViewModel viewModel = clientService.GetClient(id);

            return View(viewModel);
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ClientViewModel viewModel)
        {
            try
            {
                clientService.DeleteClient(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
