using System.Collections.Generic;
using DataAccess.EntityFramework;

namespace BusinessLayer.DataServices
{
    public interface IBorrowedBookDataService
    {
        IEnumerable<BorrowedBook> GetBorrowedBooks();
        void AddBorrowedBook(BorrowedBook borrowedBook);
        BorrowedBook GetBorrowedBook(int id);
        void EditBorrowedBook(BorrowedBook borrowedBook);
        void DeleteBorrowedBook(BorrowedBook borrowedBook);
    }
}
