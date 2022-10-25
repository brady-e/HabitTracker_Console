using HabitTracker_Console.Data;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker_Console.Models
{
    internal class MenuController
    {
        public static void menu_options()
        {
            bool endApp = false;
            while (!endApp)
            {
                string menu_response = Menu();
                switch (menu_response)
                {
                    case "i":
                        Console.Clear();
                        var date = GetDateInput("Enter the date.\n");
                        int quantity = GetNumberInput("\nEnter the amount of water you drank and press enter.\n");
                        HabitRepository.InsertHabit(date, quantity);
                        break;
                    case "r":
                        Console.Clear();
                        HabitRepository.GetAllRecords();
                        break;
                    case "u":
                        Console.Clear();
                        HabitRepository.GetAllRecords();
                        int Id_to_update = GetNumberInput("Enter the Id of the entry you want to update.\n");
                        int new_quantity = GetNumberInput("Enter the new quantity.\n");
                        break;
                    case "d":
                        Console.Clear();
                        HabitRepository.GetAllRecords();
                        int Id_to_delete = GetNumberInput("Enter the Id you wish to delete.");
                        HabitRepository.Delete(Id_to_delete);
                        break;
                    case "x":
                        Console.Clear();
                        Console.WriteLine("You are about to clear the entire log. Enter X to continue, or enter any other key to return to the menu.\n");
                        string userConfirm = Console.ReadLine();
                        if (userConfirm.ToLower() == "x")
                        {
                            HabitRepository.Delete();
                            Console.WriteLine("The log has been cleared!");
                        }
                        break;
                    case "t":
                        Console.Clear();
                        int total_months = GetNumberInput("How many months would you like to toal?\n");
                        int total = HabitRepository.TotalEntries(total_months);
                        Console.WriteLine("________________________________\n");
                        Console.WriteLine($"Total for {total_months} months is {total}.\n");
                        break;
                    case "e":
                        Console.Clear();
                        endApp = true;
                        break;
                    default:
                        Console.WriteLine("Error! Please select an option from the menu.");
                        break;
                }
            }
        }

        private static string Menu()
        {
            Console.WriteLine($@"
Type an option from below:
I - Insert new entry
R - Read existing log entries
U - Update an entry
D - Delete an entry
T - Total the log
X - Clear the log
E - Exit the app
");

            string menu_response = Console.ReadLine();
            menu_response = menu_response.ToLower();
            return menu_response;
        }

        private static int GetNumberInput(string message)
        {
            Console.WriteLine(message);
            var numInput = Console.ReadLine();

            while (!Int32.TryParse(numInput, out _) || Convert.ToInt32(numInput) < 0)
            {
                Console.WriteLine("\n\nInvalid number. Please try again.\n\n");
                numInput = Console.ReadLine();
            }
            int finalInput = Convert.ToInt32(numInput);

            return finalInput;
        }

        private static DateTime GetDateInput(string message)
        {
            Console.WriteLine(message);
            string dateInput = Console.ReadLine();
            DateTime dateCheck;

            string format = "yyyy-MM-dd";
            while (!DateTime.TryParseExact(dateInput, format, new CultureInfo("en-US"), DateTimeStyles.None, out dateCheck))
            {
                Console.Write("\n\nInvalid date. Please try again using the format yyyy-MM-dd.\n\n");
                dateInput = Console.ReadLine();
            }
            var finalInput = DateTime.ParseExact(dateInput, "yyyy-MM-dd", new CultureInfo("en-US"));
            return finalInput;
        }
    }
}
