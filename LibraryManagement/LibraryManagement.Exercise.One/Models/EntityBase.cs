namespace LibraryManagement.Exercise.One.Models
{
    public abstract class EntityBase<T> : IEntity<T>
    {
        public required T Id { get; set; }
    }
}
