namespace LibraryManagement.Exercise.One.Models
{
    public static class Library
    {
        public static ICollection<Author> Authors { get; set; } = new List<Author>();

        public static ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();

        public static ICollection<Book> Books { get; set; } = new List<Book>();

        public static ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        public static ICollection<Artist> Artists { get; set; } = new List<Artist>();

        public static ICollection<Disk> Disks { get; set; } = new List<Disk>();

        public static ICollection<Track> Tracks { get; set; } = new List<Track>();
    }
}
