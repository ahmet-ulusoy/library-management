using LibraryManagement.Exercise.Three.Models;
using LibraryManagement.Exercise.Three.Services.Abstract;
using LibraryManagement.Exercise.Three.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace LibraryManagement.Exercise.Three
{
    public static class Program
    {
        public static ICollection<Room> Rooms { get; set; } = new List<Room>();
        public static ICollection<Row> Rows { get; set; } = new List<Row>();
        public static ICollection<Shelf> Shelves { get; set; } = new List<Shelf>();
        public static ICollection<Book> Books { get; set; } = new List<Book>();
        public static ICollection<BookLocation> BookLocations { get; set; } = new List<BookLocation>();

        private static ServiceProvider? _serviceProvider;

        private static IRoomService? _roomService;

        private static IRowService? _rowService;

        private static IShelfService? _shelfService;

        private static IBookService? _bookService;

        private static IBookLocationService? _bookLocationService;

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to library manager, exercise three");

            Console.WriteLine();

            RegisterServices();

            GetRegisteredServices();

            InsertRooms();

            InsertRows();

            InsertShelves();

            InsertBooksAndBookLocations();

            CheckBookLocation();
        }

        private static void RegisterServices()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<IRoomService, RoomService>()
                .AddSingleton<IRowService, RowService>()
                .AddSingleton<IShelfService, ShelfService>()
                .AddSingleton<IBookService, BookService>()
                .AddSingleton<IBookLocationService, BookLocationService>()
                .BuildServiceProvider();
        }

        private static void GetRegisteredServices()
        {
            if (_serviceProvider != null)
            {
                _roomService = _serviceProvider.GetRequiredService<IRoomService>();

                if (_roomService == null)
                {
                    throw new InvalidOperationException($"{nameof(_roomService)} is null.");
                }

                _rowService = _serviceProvider.GetRequiredService<IRowService>();

                if (_rowService == null)
                {
                    throw new InvalidOperationException($"{nameof(_rowService)} is null.");
                }

                _shelfService = _serviceProvider.GetRequiredService<IShelfService>();

                if (_shelfService == null)
                {
                    throw new InvalidOperationException($"{nameof(_shelfService)} is null.");
                }

                _bookService = _serviceProvider.GetRequiredService<IBookService>();

                if (_bookService == null)
                {
                    throw new InvalidOperationException($"{nameof(_bookService)} is null.");
                }

                _bookLocationService = _serviceProvider.GetRequiredService<IBookLocationService>();

                if (_bookLocationService == null)
                {
                    throw new InvalidOperationException($"{nameof(_bookLocationService)} is null.");
                }
            }
        }

        private static void InsertRooms()
        {
            if (_roomService != null)
            {
                for (var i = 1; i <= 10; i++)
                {
                    var room = new Room
                    {
                        Id = i,
                        Name = $"Room {i}",
                        OrderNo = i
                    };

                    _roomService.InsertRoom(room);
                }
            }
        }

        private static void InsertRows()
        {
            if (Rooms != null && Rooms.Any() && _rowService != null)
            {
                foreach (var room in Rooms)
                {
                    for (var i = 1; i <= 10; i++)
                    {
                        var row = new Row
                        {
                            Id = (room.Id - 1) * 10 + i,
                            RoomId = room.Id,
                            Name = $"Row {(room.Id - 1) * 10 + i}",
                            OrderNo = (room.Id - 1) * 10 + i,
                            Room = room
                        };

                        _rowService.InsertRow(row);
                    }
                }
            }
        }

        private static void InsertShelves()
        {
            if (Rows != null && Rows.Any() && _shelfService != null)
            {
                foreach (var row in Rows)
                {
                    for (var i = 1; i <= 10; i++)
                    {
                        var shelf = new Shelf
                        {
                            Id = (row.Id - 1) * 10 + i,
                            RowId = row.Id,
                            Name = $"Shelf {(row.Id - 1) * 10 + i}",
                            OrderNo = (row.Id - 1) * 10 + i,
                            Row = row
                        };

                        _shelfService.InsertShelf(shelf);
                    }
                }
            }
        }

        private static void InsertBooksAndBookLocations()
        {
            if (Shelves != null && Shelves.Any() && _bookService != null && _bookLocationService != null)
            {
                foreach (var shelf in Shelves)
                {
                    var book = new Book
                    {
                        Id = shelf.Id,
                        Title = $"Title {shelf.Id}",
                        Authors = new List<string>
                        {
                            $"Author {shelf.Id}"
                        },
                        Publisher = $"Publisher {shelf.Id}",
                        Isbn = $"ISBN {shelf.Id}",
                        NumberOfPages = new Random(Convert.ToInt32(shelf.Id)).Next() % 1000,
                        PublicationYear = (int)(1900 + (shelf.Id % 100))
                    };

                    _bookService.InsertBook(book);

                    var bookLocation = new BookLocation
                    {
                        Id = shelf.Id,
                        BookId = book.Id,
                        ShelfId = shelf.Id,
                        RowId = shelf.Row.Id,
                        RoomId = shelf.Row.Room.Id,
                        Book = book,
                        Shelf = shelf,
                        Row = shelf.Row,
                        Room = shelf.Row.Room
                    };

                    _bookLocationService.InsertBookLocation(bookLocation);
                }
            }
        }

        private static void CheckBookLocation()
        {
            var book11 = Books.Single(p => p.Title == "Title 11");
            var shelf11 = Shelves.Single(p => p.Id == 11);
            var row2 = Rows.Single(p => p.Id == 2);
            var room1 = Rooms.Single(p => p.Id == 1);

            var book11TestLocation = new BookLocation
            {
                Id = 11,
                BookId = 11,
                ShelfId = 11,
                RowId = 2,
                RoomId = 1,
                Book = book11,
                Shelf = shelf11,
                Row = row2,
                Room = room1
            };

            var book11Location = BookLocations.Single(p => p.BookId == 11);

            if (JsonConvert.SerializeObject(book11TestLocation) == JsonConvert.SerializeObject(book11Location))
            {
                Console.WriteLine("Location checked");
            }
        }
    }
}
