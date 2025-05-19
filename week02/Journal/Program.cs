using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        string[] quotes = {
            "The best way to predict the future is to create it.",
            "Journaling is like whispering to oneself and listening at the same time.",
            "Each day is a new page in your story.",
            "Reflect on your progress, not your perfection.",
            "Write what should not be forgotten.",
            "A journal is your sanctuary to think, feel, and dream."
        };

        Random random = new Random();
        string randomQuote = quotes[random.Next(quotes.Length)];

        Console.WriteLine("\nWelcome to the Journal Project!");
        Console.WriteLine($"Motivational Quote: \"{randomQuote}\"\n");

        Journal journal = new Journal(); 
        PromptGenerator promptGenerator = new PromptGenerator();
        

        string choice = "";
        while (choice !="5")
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal ");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option:");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string _promptText = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"Prompt:{_promptText}");
                Console.Write("Your response:");

                string _entryText = Console.ReadLine();
                DateTime theCurrentTime = DateTime.Now;
                string _date = theCurrentTime.ToShortDateString();
        

                journal.AddEntry(new Entry(_date, _promptText, _entryText));
            }
            else if (choice == "2")
            {
                    journal.DisplayAll();
            }
            else if (choice == "3") 
            {
                Console.Write("Enter filename to save: ");
                string saveFile = Console.ReadLine();
                journal.SaveToCSV(saveFile);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load:");
                string loadFile = Console.ReadLine();
                journal.LoadFromCSV(loadFile);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice! Please try again.");
            }
                

        }



    }
}