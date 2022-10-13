using HabitTracker_Console.Data;
using System.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your habit tracker!");
        Console.WriteLine("_______________________________\n");

        // Create the repository.
        HabitRepository.CreateDatabase();

        Menu();

    }

    private static void Menu()
    {
        bool endApp = false;

        while (!endApp)
        {
            Console.WriteLine(@"Type an option from below:
            U - Update log with new entry
            R - Read existing logs
            T - See habit total
            X - Clear the log
            E - Exit the app");

            string menu_response = Console.ReadLine();
            menu_response = menu_response.ToLower();

            var date = DateTime.UtcNow;

            switch (menu_response)
            {
                case "u":
                    Console.WriteLine("Update");
                    Console.WriteLine("Type the amount of water you drank and press enter.\n");
                    var quantity = Console.ReadLine();
                    double clean_quantity = 0;
                    while (!double.TryParse(quantity, out clean_quantity))
                    {
                        Console.WriteLine("This is not a valid input. Please enter an integer value.");
                        quantity = Console.ReadLine();
                    }
                    HabitRepository.InsertHabit(date, clean_quantity);
                    break;
                case "r":
                    Console.WriteLine("Read");
                    break;
                case "t":
                    Console.WriteLine("See habit total");
                    break;
                case "x":
                    Console.WriteLine("Clear the log");
                    break;
                case "e":
                    endApp = true;
                    break;
                default:
                    Console.WriteLine("Error! Please select an option from the menu.");
                    break;
            }
        }
    }
}