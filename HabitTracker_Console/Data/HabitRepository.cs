using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
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
                        Curr_date TEXT,
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
                    insertCmd.CommandText = @"INSERT INTO drinking_water (Curr_date, Quantity) VALUES ($dateTime,$quantity)";
                    insertCmd.Parameters.AddWithValue("$dateTime",dateTime.ToString("yyyy-MM-dd"));
                    insertCmd.Parameters.AddWithValue("$quantity",quantity);
                    connection.Open();
                    insertCmd.ExecuteNonQuery();
                    
                }
            }
        }
        public static void Delete(int ID = -1)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var deleteCmd = connection.CreateCommand())
                {
                    // Define command parameters.
                    if (ID == -1)
                    {
                        deleteCmd.CommandText = @"DELETE FROM drinking_water";
                    }
                    else
                    {
                        deleteCmd.CommandText = $@"DELETE FROM drinking_water WHERE Id={ID}";
                    }
                    connection.Open();
                    deleteCmd.ExecuteNonQuery();

                }
            }
        }

        public static void GetAllRecords()
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
                    // Print results
                    Console.WriteLine("___________________________________\n");
                    foreach (var dw in tableData)
                    {
                        Console.WriteLine($"{dw.ID} - {dw.Date.ToString("dd-MMM-yyyy")} - Quantity: {dw.Quantity}");
                    }
                    Console.WriteLine("___________________________________\n");
                }
            }
        }

        public static int TotalEntries(int total_months)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var totalCmd = connection.CreateCommand())
                {
                    DateTime today_date = DateTime.Today;
                    var old_date = today_date.AddMonths(-1*total_months);

                    totalCmd.CommandText = @"SELECT SUM(Quantity) FROM drinking_water WHERE date(curr_date) BETWEEN date(@sum_date) AND date(@today)";
                    totalCmd.Parameters.AddWithValue("@sum_date", old_date.ToString("yyyy-MM-dd"));
                    totalCmd.Parameters.AddWithValue("@today", today_date.ToString("yyyy-MM-dd"));

                    connection.Open();
                    var total = totalCmd.ExecuteScalar();

                    int total_int = Convert.ToInt32(total);

                    return (total_int);
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
