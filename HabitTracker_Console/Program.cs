using HabitTracker_Console.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your habit tracker!");

        HabitRepository.CreateDatabase();
    }
}