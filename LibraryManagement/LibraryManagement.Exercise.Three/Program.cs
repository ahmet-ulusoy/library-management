using LibraryManagement.Exercise.Three.Models;

namespace LibraryManagement.Exercise.Three
{
    public static class Program
    {
        public static ICollection<Room> Rooms { get; set; } = new List<Room>();
        public static ICollection<Row> Rows { get; set; } = new List<Row>();
        public static ICollection<Shelf> Shelves { get; set; } = new List<Shelf>();
        public static ICollection<Book> Books { get; set; } = new List<Book>();
        public static ICollection<BookLocation> BookLocations { get; set; } = new List<BookLocation>();

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to library manager, exercise three");

            Console.WriteLine();
        }
    }
}