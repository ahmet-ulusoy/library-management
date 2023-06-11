using LibraryManagement.Exercise.Three.Models;
using LibraryManagement.Exercise.Three.Services.Abstract;

namespace LibraryManagement.Exercise.Three.Services.Concrete
{
    public class RowService : IRowService
    {
        public void InsertRow(Row row)
        {
            if (row == null)
            {
                throw new ArgumentNullException(nameof(row), $"{nameof(row)} is null.");
            }

            Program.Rows.Add(row);
        }
    }
}
