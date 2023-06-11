namespace LibraryManagement.Exercise.One.Models
{
    public class Disk : BaseLibraryItem
    {
        public virtual ICollection<Track>? Tracks { get; set; }

        public virtual TimeSpan? GetTotalDuration()
        {
            if (Tracks == null || Tracks.Any())
            {
                return TimeSpan.Zero;
            }

            return new TimeSpan(Tracks.Sum(p => p.Duration.Ticks));
        }

        public virtual List<string> GetTitles()
        {
            if (Tracks == null || !Tracks.Any())
            {
                return new List<string>();
            }

            return Tracks.Select(p => p.Title).ToList();
        }

        public virtual List<string> GetArtistNames()
        {
            if (Tracks == null || !Tracks.Any())
            {
                return new List<string>();
            }

            return Tracks.Select(p => p.Artist.Name).ToList();
        }
    }
}
