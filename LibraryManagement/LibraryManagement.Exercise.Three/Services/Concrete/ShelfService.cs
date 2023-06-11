using LibraryManagement.Exercise.Three.Models;
using LibraryManagement.Exercise.Three.Services.Abstract;

namespace LibraryManagement.Exercise.Three.Services.Concrete
{
    public class ShelfService : IShelfService
    {
        public void InsertShelf(Shelf shelf)
        {
            if (shelf == null)
            {
                throw new ArgumentNullException(nameof(shelf), $"{nameof(shelf)} is null.");
            }

            Program.Shelves.Add(shelf);
        }
    }
}
