using BusinessLayer.ViewModels;

namespace BusinessLayer.Services
{
    public interface IBookService
    {
        ListBookViewModel GetBooks();
        void Add(BookViewModel viewModel);
        BookViewModel GetBook(int id);
        void EditBook(BookViewModel viewModel);
        void Delete(int id);
    }
}
