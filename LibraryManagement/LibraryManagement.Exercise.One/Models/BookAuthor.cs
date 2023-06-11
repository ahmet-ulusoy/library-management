using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Exercise.One.Models
{
    public class BookAuthor : EntityBase<long>
    {
        [Required]
        public long BookId { get; set; }

        [Required]
        public long AuthorId { get; set; }

        public virtual Book Book { get; set; } = null!;

        public virtual Author Author { get; set; } = null!;
    }
}
