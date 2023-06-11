namespace LibraryManagement.Exercise.Three.Models
{
    public class BookLocation
    {
        public long Id { get; set; }

        public long BookId { get; set; }

        public long RoomId { get; set; }

        public long RowId { get; set; }

        public long ShelfId { get; set; }

        public virtual Book Book { get; set; } = null!;

        public virtual Room Room { get; set; } = null!;

        public virtual Row Row { get; set; } = null!;

        public virtual Shelf Shelf { get; set; } = null!;
    }
}
