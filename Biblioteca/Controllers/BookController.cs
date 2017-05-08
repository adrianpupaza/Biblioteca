using System.Web.Mvc;
using BusinessLayer.Services;
using BusinessLayer.ViewModels;

namespace Biblioteca.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController()
        {
            bookService = new BookService();
        }

        // GET: Book
        public ActionResult Index()
        {
            ListBookViewModel viewModel = bookService.GetBooks();

            return View(viewModel);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            BookViewModel viewModel = new BookViewModel();

            return View(viewModel);
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookViewModel viewModel)
        {
            try
            {
                bookService.Add(viewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            BookViewModel viewModel = bookService.GetBook(id);

            return View(viewModel);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookViewModel viewModel)
        {
            try
            {
                bookService.EditBook(viewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            BookViewModel viewModel = bookService.GetBook(id);

            return View(viewModel);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BookViewModel viewModel)
        {
            try
            {
                bookService.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
