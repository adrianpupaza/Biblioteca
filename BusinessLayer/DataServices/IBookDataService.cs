using System.Collections.Generic;
using DataAccess.EntityFramework;

namespace BusinessLayer.DataServices
{
    public interface IBookDataService
    {
        IEnumerable<Book> GetBooks();
        void AddBook(Book book);
        Book GetBook(int id);
        void EditBook(Book book);
        void DeleteBook(Book book);
    }
}
