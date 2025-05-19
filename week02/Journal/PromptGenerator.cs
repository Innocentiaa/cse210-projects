using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person you interacted with today?",
        "What was the best part of your day?",
        "What made you smile today?",
        "What was the strongest emotion you felt today?",
        "What would you like to improve tomorrow?",
        "What is one moment from today you wish you could relive?",
        "What inspired you the most today?",
        "What was one decision you made today that you feel good about?",
        "What's a question you have after reflecting on your day?",
        "What's something you're looking forward to tomorrow?",
        "How did you connect with someone today?",
         "If you could send a message to your future self about today, what would it be?"     

    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}