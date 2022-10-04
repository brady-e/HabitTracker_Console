using Microsoft.Data.Sqlite;


namespace HabitTracker_Console.Data
{
    internal class HabitRepository
    {
        static readonly string connectionString = @"Data Source=habit-Tracker.db";
        void CreateDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {

                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS yourHabit (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Quantity INTEGER
                        )";

                    tableCmd.ExecuteNonQuery();
                }

            }
        }

        void InsertHabit(DateTime dateTime, int quantity)
        {
            var query = "INSERT INTO yourHabit(Date, Quantity)" +
                "VALUES (@dateTime, @quantity)";

            using (var connection = new SqliteConnection(connectionString))
            {
                using (var insertCmd = connection.CreateCommand())
                {
                    // Define command parameters.
                    
                }
            }
        }

    }
}
