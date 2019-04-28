
using SQLite;

namespace TestTotalXam.Interfaces
{
    public interface IConfiguration
    {
        SQLiteConnection GetConnection();
    }
}
