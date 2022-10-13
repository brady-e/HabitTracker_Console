using Microsoft.Data.Sqlite;

namespace HabitTracker_Console.Data
{
    internal class HabitRepository
    {
        static readonly string connectionString = @"Data Source=habit-Tracker.db";
        public static void CreateDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {

                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS drinking_water (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Quantity INTEGER
                        )";

                    tableCmd.ExecuteNonQuery();
                }

            }
        }

        public static void InsertHabit(DateTime dateTime, double quantity)
        {
            var query = "INSERT INTO yourHabit(Date, Quantity)" +
                "VALUES (@dateTime, @quantity)";

            using (var connection = new SqliteConnection(connectionString))
            {
                using (var insertCmd = connection.CreateCommand())
                {
                    // Define command parameters.
                    insertCmd.CommandText = @"INSERT INTO drinking_water (Date, Quantity) VALUEs (?,?)";
                    insertCmd.Parameters.Add(dateTime);
                    insertCmd.Parameters.Add(quantity);
                    connection.Open(); // Can this be after CommandText?
                    insertCmd.ExecuteNonQuery();
                    
                }
            }
        }

    }
}
