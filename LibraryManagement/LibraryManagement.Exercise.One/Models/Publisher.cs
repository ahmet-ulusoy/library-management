using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Exercise.One.Models
{
    public class Publisher : EntityBase<long>
    {
        [Required]
        public string Name { get; set; } = null!;

        public virtual ICollection<Book>? PublishedBooks { get; set; }
    }
}
