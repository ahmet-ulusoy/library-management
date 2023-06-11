using LibraryManagement.Exercise.Two.Models;

namespace LibraryManagement.Exercise.Two.Services.Abstract
{
    public interface IBookService
    {
        List<Book> ReadBooks(string input);
        List<Book> FindBooks(string searchString);
    }
}
