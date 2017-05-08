using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.EntityFramework;

namespace BusinessLayer.DataServices
{
    public class BookDataService : IBookDataService
    {
        public IEnumerable<Book> GetBooks()
        {
            using (DbContext context = new BibliotecaEntities())
            {
                IEnumerable<Book> books = context.Set<Book>().ToList();

                return books;
            }
        }

        public void AddBook(Book book)
        {
            using (DbContext context = new BibliotecaEntities())
            {
                context.Entry(book).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public Book GetBook(int id)
        {
            using (DbContext context = new BibliotecaEntities())
            {
                Book book = context.Set<Book>().Find(id);

                return book;
            }
        }

        public void EditBook(Book book)
        {
            using (DbContext context = new BibliotecaEntities())
            {
                context.Entry(book).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void DeleteBook(Book book)
        {
            using (DbContext context = new BibliotecaEntities())
            {
                context.Entry(book).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
