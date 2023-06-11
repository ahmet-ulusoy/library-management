namespace LibraryManagement.Exercise.Three.Models
{
    public class Room
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public long OrderNo { get; set; }

        public virtual ICollection<Row>? Rows { get; set; }
    }
}
