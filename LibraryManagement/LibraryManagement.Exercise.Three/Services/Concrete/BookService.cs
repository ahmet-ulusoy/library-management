using LibraryManagement.Exercise.Three.Models;
using LibraryManagement.Exercise.Three.Services.Abstract;

namespace LibraryManagement.Exercise.Three.Services.Concrete
{
    public class BookService : IBookService
    {
        public void InsertBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), $"{nameof(book)} is null.");
            }

            Program.Books.Add(book);
        }
    }
}
