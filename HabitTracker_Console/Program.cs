using HabitTracker_Console.Data;
using HabitTracker_Console.Models;
using System.Data;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your habit tracker!");
        Console.WriteLine("_______________________________\n");

        // Create the repository.
        HabitRepository.CreateDatabase();

        // Call the menu loop from Menu_Controller
        MenuController.menu_options();

        // menu_options has been exited, program ending.
        Console.WriteLine("\n Goodybe! \n");
    }
}