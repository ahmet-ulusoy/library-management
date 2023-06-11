using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Exercise.One.Models
{
    public abstract class BaseLibraryItem : EntityBase<long>
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required, MinLength(13), MaxLength(13)]
        public string Isbn { get; set; } = null!;

        [Required]
        public bool IsDownloadable { get; set; }

        public string? DownloadLink { get; set; }
    }
}
