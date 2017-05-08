using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.EntityFramework;

namespace BusinessLayer.DataServices
{
    public class BorrowedBookDataService : IBorrowedBookDataService
    {
        public IEnumerable<BorrowedBook> GetBorrowedBooks()
        {
            using (DbContext context = new BibliotecaEntities())
            {
                IEnumerable<BorrowedBook> borrowedBooks = context.Set<BorrowedBook>().ToList();

                return borrowedBooks;
            }
        }

        public void AddBorrowedBook(BorrowedBook borrowedBook)
        {
            using (DbContext context = new BibliotecaEntities())
            {
                context.Entry(borrowedBook).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public BorrowedBook GetBorrowedBook(int id)
        {
            using (DbContext context = new BibliotecaEntities())
            {
                BorrowedBook borrowedBook = context.Set<BorrowedBook>().Find(id);

                return borrowedBook;
            }
        }

        public void EditBorrowedBook(BorrowedBook borrowedBook)
        {
            using (DbContext context = new BibliotecaEntities())
            {
                context.Entry(borrowedBook).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteBorrowedBook(BorrowedBook borrowedBook)
        {
            using (DbContext context = new BibliotecaEntities())
            {
                context.Entry(borrowedBook).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
