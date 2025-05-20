public class Entry
{
    public string Date;
    public string Prompt;
    public string Text;

    public Entry(string date, string prompt, string text)
    {
        Date = date;
        Prompt = prompt;
        Text = text;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Text}");
        Console.WriteLine("---------------------------");
    }
    

}