using System.Web.Mvc;
using BusinessLayer.Services;
using BusinessLayer.ViewModels;

namespace Biblioteca.Controllers
{
    public class BorrowedBookController : Controller
    {
        private readonly IBorrowedBookService borrowedBookService;

        public BorrowedBookController()
        {
            borrowedBookService = new BorrowedBookService();
        }
        // GET: BorrowedBook
        public ActionResult Index(bool returned = false)
        {
            ListBorrowedBookViewModel viewModel = borrowedBookService.GetBorrowedBooks();

            return View(viewModel);
        }

        // GET: BorrowedBook/Create
        public ActionResult Create()
        {
            BorrowedBookViewModel viewModel = new BorrowedBookViewModel();

            borrowedBookService.LoadProperties(viewModel);

            return View(viewModel);
        }

        // POST: BorrowedBook/Create
        [HttpPost]
        public ActionResult Create(BorrowedBookViewModel viewModel)
        {
            try
            {
                borrowedBookService.AddBorrowedBook(viewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BorrowedBook/Edit/5
        public ActionResult Edit(int id)
        {
            BorrowedBookViewModel viewModel = borrowedBookService.GetBorrowedBook(id);

            borrowedBookService.LoadProperties(viewModel);

            return View(viewModel);
        }

        // POST: BorrowedBook/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BorrowedBookViewModel viewModel)
        {
            try
            {
                borrowedBookService.EditBorrowedBook(viewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            BorrowedBookViewModel viewModel = borrowedBookService.GetBorrowedBook(id);

            return View(viewModel);
        }

        // POST: BorrowedBook/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BorrowedBookViewModel viewModel)
        {
            try
            {
                borrowedBookService.DeleteBorrowedBook(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Return(int id)
        {
            try
            {
                borrowedBookService.ReturnBorrowedBook(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
