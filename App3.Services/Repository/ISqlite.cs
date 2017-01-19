using SQLite;

namespace App3
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}