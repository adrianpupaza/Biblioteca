using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer.DataServices;
using BusinessLayer.ViewModels;
using DataAccess.EntityFramework;

namespace BusinessLayer.Services
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly IBorrowedBookDataService borrowedBookDataService;
        private readonly IClientService clientService;
        private readonly IBookService bookService;

        public BorrowedBookService()
        {
            borrowedBookDataService = new BorrowedBookDataService();
            clientService = new ClientService();
            bookService = new BookService();
        }
        public ListBorrowedBookViewModel GetBorrowedBooks()
        {
            IEnumerable<BorrowedBook> borrowedBooks = borrowedBookDataService.GetBorrowedBooks();
            IList<BorrowedBookViewModel> viewModels = new List<BorrowedBookViewModel>();

            foreach (BorrowedBook borrowedBook in borrowedBooks)
            {
                ClientViewModel client = clientService.GetClient(borrowedBook.ClientId);
                BookViewModel book = bookService.GetBook(borrowedBook.BookId);

                viewModels.Add(new BorrowedBookViewModel
                {
                    Id = borrowedBook.Id,
                    BookId = borrowedBook.BookId,
                    ClientId = borrowedBook.ClientId,
                    Returned = borrowedBook.Returned,
                    ClientName = client.FirstName + " " + client.LastName,
                    BookTitle = book.Title,
                    Author = book.Author
                });
            }
                
            ListBorrowedBookViewModel viewModel = new ListBorrowedBookViewModel
            {
                BorrowedBooks = viewModels
            };

            return viewModel;
        }

        public void AddBorrowedBook(BorrowedBookViewModel viewModel)
        {
            BorrowedBook borrowedBook = new BorrowedBook
            {
                BookId = viewModel.BookId,
                ClientId = viewModel.ClientId,
                Returned = false
            };

            borrowedBookDataService.AddBorrowedBook(borrowedBook);
        }

        public BorrowedBookViewModel GetBorrowedBook(int id)
        {
            BorrowedBook borrowedBook = borrowedBookDataService.GetBorrowedBook(id);

            ClientViewModel client = clientService.GetClient(borrowedBook.ClientId);
            BookViewModel book = bookService.GetBook(borrowedBook.BookId);

            BorrowedBookViewModel viewModel = new BorrowedBookViewModel
            {
                Id = borrowedBook.Id,
                BookId = borrowedBook.BookId,
                ClientId = borrowedBook.ClientId,
                Returned = borrowedBook.Returned,
                ClientName = client.FirstName + " " + client.LastName,
                BookTitle = book.Title,
                Author = book.Author
            };

            return viewModel;
        }

        public void EditBorrowedBook(BorrowedBookViewModel viewModel)
        {
            BorrowedBook borrowedBook = new BorrowedBook
            {
                Id = viewModel.Id,
                BookId = viewModel.BookId,
                ClientId = viewModel.ClientId,
                Returned = viewModel.Returned
            };

            borrowedBookDataService.EditBorrowedBook(borrowedBook);
        }

        public void DeleteBorrowedBook(int id)
        {
            BorrowedBook borrowedBook = borrowedBookDataService.GetBorrowedBook(id);

            borrowedBookDataService.DeleteBorrowedBook(borrowedBook);
        }

        public void LoadProperties(BorrowedBookViewModel viewModel)
        {
            viewModel.Clients = clientService.GetClients().Clients.Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.LastName,
                Value = x.Id.ToString()
            });

            viewModel.Books = bookService.GetBooks().Books.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.ToString()
            });
        }

        public void ReturnBorrowedBook(int id)
        {
            BorrowedBook borrowedBook = borrowedBookDataService.GetBorrowedBook(id);

            borrowedBook.Returned = true;

            borrowedBookDataService.EditBorrowedBook(borrowedBook);
        }
    }
}
