using LibraryManagement.Exercise.One.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Exercise.One.Models
{
    public class Track : EntityBase<long>
    {
        [Required]
        public long DiskId { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public long ArtistId { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public byte TrackContentTypeId { get; set; }

        public virtual Disk Disk { get; set; } = null!;

        public virtual Artist Artist { get; set; } = null!;

        public virtual TrackContentType TrackContentType { get; set; }

        public virtual string GetDiskName()
        {
            if (Disk == null)
            {
                return string.Empty;
            }

            return Disk.Name;
        }

        public virtual string GetArtistName()
        {
            if (Artist == null)
            {
                return string.Empty;
            }

            return Artist.Name;
        }
    }
}
