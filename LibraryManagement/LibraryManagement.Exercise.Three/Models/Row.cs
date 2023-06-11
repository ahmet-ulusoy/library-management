namespace LibraryManagement.Exercise.Three.Models
{
    public class Row
    {
        public long Id { get; set; }

        public long RoomId { get; set; }

        public string Name { get; set; } = null!;

        public long OrderNo { get; set; }

        public virtual Room Room { get; set; } = null!;

        public virtual ICollection<Shelf>? Shelves { get; set; }
    }
}
