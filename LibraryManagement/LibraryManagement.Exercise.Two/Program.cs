using LibraryManagement.Exercise.Two.Models;

namespace LibraryManagement.Exercise.Two
{
    public static class Program
    {
        public static ICollection<Book> Books { get; set; } = new List<Book>();

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to library manager, exercise two");

            Console.WriteLine();
        }
    }
}