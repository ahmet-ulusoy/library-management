namespace LibraryManagement.Exercise.Three.Models
{
    public class Shelf
    {
        public long Id { get; set; }

        public long RowId { get; set; }

        public string Name { get; set; } = null!;

        public long OrderNo { get; set; }

        public virtual Row Row { get; set; } = null!;
    }
}
