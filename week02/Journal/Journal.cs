using System.Net;
using System.IO;
using System.Collections.Generic;



public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal yet.");
            return;
        }
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }
    

    public void SaveToCSV(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine("Date,Prompt,Response,Mood");
            foreach ( var entry in _entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Text}");
            }
        }
        Console.WriteLine("Journal saved successfully.");

    }

    public void LoadFromCSV(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found!");
            return;
        }
        _entries.Clear();
        using (StreamReader reader = new StreamReader(file))
        {
            string header = reader.ReadLine();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    _entries.Add(new Entry(parts[0], parts[1], parts[2]));
                }
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }


}