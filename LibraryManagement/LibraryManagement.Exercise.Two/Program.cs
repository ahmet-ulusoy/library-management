using LibraryManagement.Exercise.Two.Models;
using LibraryManagement.Exercise.Two.Services.Abstract;
using LibraryManagement.Exercise.Two.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace LibraryManagement.Exercise.Two
{
    public static class Program
    {
        public static ICollection<Book> Books { get; set; } = new List<Book>();

        private static ServiceProvider? _serviceProvider;

        private static IBookService? _bookService;

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to library manager, exercise two");

            Console.WriteLine();

            RegisterServices();

            GetBookService();

            var input = ReadFileContentAsString();

            if (_bookService != null)
            {
                Books = _bookService.ReadBooks(input);

                Console.WriteLine($"Read Books: ");

                foreach (var book in Books)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(book));
                }
            }
        }

        private static void RegisterServices()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<IBookService, BookService>()
                .BuildServiceProvider();
        }

        private static void GetBookService()
        {
            if (_serviceProvider != null)
            {
                _bookService = _serviceProvider.GetRequiredService<IBookService>();

                if (_bookService == null)
                {
                    throw new InvalidOperationException($"{nameof(_bookService)} is null.");
                }
            }
        }

        private static string ReadFileContentAsString()
        {
            var file = new StreamReader(Path.Combine("..\\..\\..", "Input.txt"));

            var fileAsString = file.ReadToEnd();

            file.Close();

            file.Dispose();

            return fileAsString;
        }
    }
}
