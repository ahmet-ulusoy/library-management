using LibraryManagement.Exercise.Two.Models;
using LibraryManagement.Exercise.Two.Services.Abstract;

namespace LibraryManagement.Exercise.Two.Services.Concrete
{
    public class BookService : IBookService
    {
        public List<Book> FindBooks(string searchString)
        {
            throw new NotImplementedException();
        }

        // If I were you I might try serialize/desearilize objects with json
        // As you know dotnet won't let you make binary serialization/deserialization after .net 5
        // But if you want to use you can add .csproj file below line
        // <EnableUnsafeBinaryFormatterSerialization>true</EnableUnsafeBinaryFormatterSerialization>
        // I tried but it gave me byte errors and I had to do like that
        public List<Book> ReadBooks(string input)
        {
            var tempBooks = new List<Book>();

            var booksAsString = input.Split("Book:");

            foreach (var bookAsString in booksAsString)
            {
                if (!string.IsNullOrEmpty(bookAsString))
                {
                    var tempBook = new Book();

                    var lines = bookAsString.Split("\r\n");

                    foreach (var line in lines)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            if (line.Contains("Author:"))
                            {
                                tempBook.Authors.Add(line.Replace("Author:", string.Empty).TrimStart(' ').TrimEnd(' '));
                            }
                            else if (line.Contains("Title"))
                            {
                                tempBook.Title = line.Replace("Title:", string.Empty).TrimStart(' ').TrimEnd(' ');
                            }
                            else if (line.Contains("Publisher"))
                            {
                                tempBook.Publisher = line.Replace("Publisher:", string.Empty).TrimStart(' ').TrimEnd(' ');
                            }
                            else if (line.Contains("Published"))
                            {
                                tempBook.PublicationYear = Convert.ToInt32(line.Replace("Published:", string.Empty).TrimStart(' ').TrimEnd(' '));
                            }
                            else if (line.Contains("NumberOfPages"))
                            {
                                tempBook.NumberOfPages = Convert.ToInt32(line.Replace("NumberOfPages:", string.Empty).TrimStart(' ').TrimEnd(' '));
                            }
                        }
                    }

                    if (tempBook == null)
                    {
                        throw new InvalidOperationException($"{nameof(tempBook)} is null.");
                    }

                    if (tempBook.Authors == null || !tempBook.Authors.Any())
                    {
                        throw new InvalidOperationException($"{nameof(tempBook.Authors)} is null or doesn't contain any items.");
                    }

                    if (string.IsNullOrEmpty(tempBook.Title))
                    {
                        throw new InvalidOperationException($"{nameof(tempBook.Title)} is null or empty.");
                    }

                    if (string.IsNullOrEmpty(tempBook.Publisher))
                    {
                        throw new InvalidOperationException($"{nameof(tempBook.Publisher)} is null or empty.");
                    }

                    if (tempBook.PublicationYear <= 0)
                    {
                        throw new InvalidOperationException($"{nameof(tempBook.PublicationYear)} can't be equal to zero or a negative number.");
                    }

                    if (tempBook.NumberOfPages <= 0)
                    {
                        throw new InvalidOperationException($"{nameof(tempBook.NumberOfPages)} can't be equal to zero or a negative number.");
                    }

                    tempBooks.Add(tempBook);
                }
            }

            return tempBooks;
        }
    }
}
