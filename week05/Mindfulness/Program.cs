using System;

class Program
{
    static void Main(string[] args)
    {

        Log sessionLog = new Log();
        
        while (true)
        {
            Console.WriteLine("\nMindfulness Activities Menu");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                var activity = new BreathingActivity(sessionLog);
                activity.Run();
            }
            else if (choice == "2")
            {
                var activity = new ListingActivity();
                activity.Run();
            }
            else if (choice == "3")
            {
                var activity = new ReflectingActivity();
                activity.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }
    }
}