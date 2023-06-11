using LibraryManagement.Exercise.Two.Models;
using LibraryManagement.Exercise.Two.Services.Abstract;
using LibraryManagement.Exercise.Two.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
