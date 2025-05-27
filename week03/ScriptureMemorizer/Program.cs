using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorization Program!");
        Console.WriteLine("1. Memorize a new scripture.");
        Console.WriteLine("2. View saved memorized scriptures.");
        Console.Write("Choose an option (1 or 2): ");
        string option = Console.ReadLine();

        if (option == "1")
        {
            // Load scriptures from a file
            List<Scripture> scriptures = ScriptureFileHandler.LoadScripturesFromFile("scriptures.txt");
            if (scriptures.Count == 0)
            {
                Console.WriteLine("No scriptures available in the file.");
                return;
            }

            // Select a random scripture
            Random random = new Random();
            Scripture scripture = scriptures[random.Next(scriptures.Count)];

            // Begin memorization
            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");

                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords(3); // Hide 3 random words each time
            }

            // Save the memorized scripture
            Console.Clear();
            Console.WriteLine("All words are hidden! Here's the scripture:\n");
            Console.WriteLine(scripture.GetDisplayText());
            ScriptureFileHandler.SaveMemorizedScripture("memorized_scriptures.txt", scripture);
            Console.WriteLine("\nScripture saved to 'memorized_scriptures.txt'.");
        }
        else if (option == "2")
        {
            // Load and display saved memorized scriptures
            ScriptureFileHandler.DisplaySavedMemorizedScriptures("memorized_scriptures.txt");
        }
        else
        {
            Console.WriteLine("Invalid option. Please restart the program.");
        }
    }
}
