using LibraryManagement.Exercise.Three.Models;
using LibraryManagement.Exercise.Three.Services.Abstract;

namespace LibraryManagement.Exercise.Three.Services.Concrete
{
    public class RoomService : IRoomService
    {
        public void InsertRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room), $"{nameof(room)} is null.");
            }

            Program.Rooms.Add(room);
        }
    }
}
