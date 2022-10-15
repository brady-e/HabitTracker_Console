using Microsoft.Data.Sqlite;
using System;
using System.Globalization;

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
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var insertCmd = connection.CreateCommand())
                {
                    // Define command parameters.
                    insertCmd.CommandText = @"INSERT INTO drinking_water (Date, Quantity) VALUES ($dateTime,$quantity)";
                    insertCmd.Parameters.AddWithValue("$dateTime",dateTime.ToString("yyyy-MM-dd HH:mm"));
                    insertCmd.Parameters.AddWithValue("$quantity",quantity);
                    connection.Open();
                    insertCmd.ExecuteNonQuery();
                    
                }
            }
        }
        public static void DeleteTable()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var deleteCmd = connection.CreateCommand())
                {
                    // Define command parameters.
                    deleteCmd.CommandText = @"DELETE FROM drinking_water";
                    connection.Open();
                    deleteCmd.ExecuteNonQuery();

                }
            }
        }

        public static List<DrinkingWater> GetAllRecords()
        {
            // Read the contents of the table.
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var readCmd = connection.CreateCommand())
                {
                    // Define command parameters.
                    readCmd.CommandText = @"SELECT * FROM drinking_water";

                    List<DrinkingWater> tableData = new();

                    connection.Open();
                    SqliteDataReader reader = readCmd.ExecuteReader();
                    //return result;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tableData.Add(
                            new DrinkingWater
                            {
                                ID = reader.GetInt32(0),
                                Date = DateTime.ParseExact(reader.GetString(1), "yyyy-MM-dd HH:mm", new CultureInfo("en-US")),
                                Quantity = reader.GetInt32(2)
                            }
                        ); ;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                    return tableData;

                }
            }

        }

        public class DrinkingWater
        {
            public int ID { get; set; }
            public DateTime Date { get; set; }
            public int Quantity { get; set; }
        }

    }
}
