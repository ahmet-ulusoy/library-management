using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Exercise.One.Models
{
    public class Book : BaseLibraryItem
    {
        [Required]
        public int NumberOfPages { get; set; }

        [Required]
        public long PublisherId { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = null!;

        public virtual Publisher Publisher { get; set; } = null!;

        public virtual List<string> GetAuthorNames()
        {
            if (BookAuthors == null || !BookAuthors.Any())
            {
                return new List<string>();
            }

            return BookAuthors.Select(p => p.Author.Name).ToList();
        }

        public virtual string GetPublisherName()
        {
            if (Publisher == null)
            {
                return string.Empty;
            }

            return Publisher.Name;
        }
    }
}
