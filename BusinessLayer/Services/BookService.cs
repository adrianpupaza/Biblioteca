using System.Linq;
using BusinessLayer.DataServices;
using BusinessLayer.ViewModels;
using DataAccess.EntityFramework;

namespace BusinessLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookDataService bookDataService;

        public BookService()
        {
            bookDataService = new BookDataService();
        }

        public ListBookViewModel GetBooks()
        {
            ListBookViewModel viewModel = new ListBookViewModel
            {
                Books = bookDataService.GetBooks().Select(x => new BookViewModel
                {
                    Id = x.Id,
                    Author = x.Author,
                    Title = x.Title,
                    Quantity = x.Quantity
                })
            };

            return viewModel;
        }

        public void Add(BookViewModel viewModel)
        {
            Book book = new Book
            {
                Id = viewModel.Id,
                Author = viewModel.Author,
                Title = viewModel.Title,
                Quantity = viewModel.Quantity
            };

            bookDataService.AddBook(book);
        }

        public BookViewModel GetBook(int id)
        {
            Book book = bookDataService.GetBook(id);

            BookViewModel bookViewModel = new BookViewModel
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Quantity = book.Quantity
            };

            return bookViewModel;
        }

        public void EditBook(BookViewModel viewModel)
        {
            Book book = new Book
            {
                Id = viewModel.Id,
                Author = viewModel.Author,
                Title = viewModel.Title,
                Quantity = viewModel.Quantity
            };

            bookDataService.EditBook(book);
        }

        public void Delete(int id)
        {
            Book book = bookDataService.GetBook(id);
            bookDataService.DeleteBook(book);
        }
    }
}
