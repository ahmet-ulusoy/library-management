namespace LibraryManagement.Exercise.One.Models
{
    public interface IEntity<out TKey>
    {
        TKey Id { get; }
    }
}
