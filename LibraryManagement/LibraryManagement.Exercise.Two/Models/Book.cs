namespace LibraryManagement.Exercise.Two.Models
{
    public class Book
    {
        public List<string> Authors { get; set; } = new List<string>();

        public string Title { get; set; } = null!;

        public string Publisher { get; set; } = null!;

        public int PublicationYear { get; set; }

        public int NumberOfPages { get; set; }
    }
}
