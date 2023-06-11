using LibraryManagement.Exercise.Three.Models;

namespace LibraryManagement.Exercise.Three
{
    public static class Program
    {
        public static List<Room> Rooms { get; set; } = new List<Room>();
        public static List<Row> Rows { get; set; } = new List<Row>();
        public static List<Shelf> Shelves { get; set; } = new List<Shelf>();
        public static List<Book> Books { get; set; } = new List<Book>();

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to library manager, exercise three");

            Console.WriteLine();
        }
    }
}