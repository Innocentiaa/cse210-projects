using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "What are your personal strengths?",
        "Who are the people you appreciate?",
        "What are some achievements you're proud of",
        "Who are your role models?",
        "Who are your personal heroes?"

    };

    public ListingActivity() : base("Listing", "This activity helps you focus on positivity by listing items.")
    {

    }

    public void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Think about your response...");
        ShowSpinner(3);
        List<string> items = GetListFromUser();
        Console.WriteLine($"You listed {items.Count} items. Well done!");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser()
    {
        Console.WriteLine("Start listing items (type 'done' to finish): ");
        List<string> items = new List<string>();
        while (true)
        {
            string item = Console.ReadLine();
            if (item?.ToLower() == "done") break;
            items.Add(item);
        }

        return items;

    }
}