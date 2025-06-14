using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        GoalManager goalManager = new GoalManager();
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a Goal ");
            Console.WriteLine("2. Record an Event");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Display Player Info ");
            Console.WriteLine("7. Quit ");

            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                if (choice == 1)
                {
                    CreateGoal(goalManager);
                }
                else if (choice == 2)
                {
                    Console.Write("Enter the name of the goal to record an event for: ");
                    string goalName = Console.ReadLine();
                    goalManager.RecordEvent(goalName);
                    goalManager.CheckLevelUp();
                }
                else if (choice == 3)
                {
                    goalManager.ListGoalDetails();
                }
                else if (choice == 4)
                {
                    Console.Write("Enter the filename to save goals: ");
                    string filename = Console.ReadLine();
                    goalManager.SaveGoals(filename);

                }
                else if (choice == 5)
                {
                    Console.Write("Enter the filename to load goals from: ");
                    string filename = Console.ReadLine();
                    goalManager.LoadGoals(filename);
                }
                else if (choice == 6)
                {
                    goalManager.DisplayPlayerInfo();
                }
                else if (choice == 7)
                {
                    quit = true;
                    Console.WriteLine("Thank you for using the EternalQuest Program. Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    private static void CreateGoal(GoalManager goalManager)
    {
        Console.WriteLine("Select the type of goal: ");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");

        string input = Console.ReadLine();

        if (int.TryParse(input, out int goalType))
        {
            Console.Write("Enter the goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the goal description: ");
            string description = Console.ReadLine();

            Console.Write("Enter the goal points: ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid points value. Please try again.");
                return;
            }

            if (goalType == 1)
            {
                goalManager.CreateGoal(new SimpleGoal(name, description, points.ToString()));
            }
            else if (goalType == 2)
            {
                goalManager.CreateGoal(new EternalGoal(name, description, points.ToString()));
            }
            else if (goalType == 3)
            {
                Console.Write("Enter the target count for the goal: ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid target value. Please try again.");
                    return;
                }

                Console.Write("Enter the bonus points for completing the goal: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus value. Please try again.");
                    return;
                }

                goalManager.CreateGoal(new ChecklistGoal(name, description, points.ToString(), target, bonus));
            }
            else
            {
                Console.WriteLine("Invalid goal type selected. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}