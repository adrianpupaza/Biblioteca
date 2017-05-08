using BusinessLayer.ViewModels;

namespace BusinessLayer.Services
{
    public interface IBorrowedBookService
    {
        ListBorrowedBookViewModel GetBorrowedBooks();
        void AddBorrowedBook(BorrowedBookViewModel viewModel);
        BorrowedBookViewModel GetBorrowedBook(int id);
        void EditBorrowedBook(BorrowedBookViewModel viewModel);
        void DeleteBorrowedBook(int id);
        void LoadProperties(BorrowedBookViewModel viewModel);
        void ReturnBorrowedBook(int id);
    }
}
