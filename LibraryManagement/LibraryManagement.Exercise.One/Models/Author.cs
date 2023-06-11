using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Exercise.One.Models
{
    public class Author : EntityBase<long>
    {
        [Required]
        public string Name { get; set; } = null!;

        public virtual ICollection<BookAuthor>? AuthoredBooks { get; set; }

        public virtual List<string> GetAuthoredBookNames()
        {
            if (AuthoredBooks == null || !AuthoredBooks.Any())
            {
                return new List<string>();
            }

            return AuthoredBooks.Select(p => p.Book.Name).ToList();
        }
    }
}
