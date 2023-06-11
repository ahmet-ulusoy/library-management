using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Exercise.One.Models
{
    public class Artist : EntityBase<long>
    {
        [Required]
        public string Name { get; set; } = null!;

        public virtual ICollection<Track>? OwnedTracks { get; set; }

        public virtual List<string> GetOwnedTrackTitles()
        {
            if (OwnedTracks == null || !OwnedTracks.Any())
            {
                return new List<string>();
            }

            return OwnedTracks.Select(p => p.Title).ToList();
        }
    }
}
