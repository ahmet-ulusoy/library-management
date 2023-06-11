using LibraryManagement.Exercise.Three.Models;
using LibraryManagement.Exercise.Three.Services.Abstract;

namespace LibraryManagement.Exercise.Three.Services.Concrete
{
    public class BookLocationService : IBookLocationService
    {
        public void InsertBookLocation(BookLocation bookLocation)
        {
            if (bookLocation == null)
            {
                throw new ArgumentNullException(nameof(bookLocation), $"{nameof(bookLocation)} is null.");
            }

            Program.BookLocations.Add(bookLocation);
        }
    }
}
