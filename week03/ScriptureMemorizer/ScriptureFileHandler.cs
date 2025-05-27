using System;
using System.Collections.Generic;
using System.IO;

public static class ScriptureFileHandler
{
    public static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    // Assuming format: "Reference|Text"
                    Reference reference = ParseReference(parts[0]);
                    if (reference != null)
                    {
                        scriptures.Add(new Scripture(reference, parts[1]));
                    }
                }
            }
        }

        return scriptures;
    }

    private static Reference ParseReference(string referenceText)
    {
        try
        {
            string[] parts = referenceText.Split(' ');
            string book = parts[0];
            string[] chapterAndVerses = parts[1].Split(':');
            int chapter = int.Parse(chapterAndVerses[0]);

            string[] verses = chapterAndVerses[1].Split('-');
            int startVerse = int.Parse(verses[0]);
            int endVerse = verses.Length > 1 ? int.Parse(verses[1]) : startVerse;

            return new Reference(book, chapter, startVerse, endVerse);
        }
        catch
        {
            return null; // Invalid format
        }
    }

    public static void SaveMemorizedScripture(string filePath, Scripture scripture)
    {
        string textToSave = $"{scripture.GetReferenceText()}|{scripture.GetScriptureText()}";
        File.AppendAllLines(filePath, new[] { textToSave });
    }

    public static void DisplaySavedMemorizedScriptures(string filePath)
    {
        if (File.Exists(filePath))
        {
            Console.WriteLine("Saved Memorized Scriptures:\n");
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    Console.WriteLine($"{parts[0]}: {parts[1]}\n");
                }
            }
        }
        else
        {
            Console.WriteLine("No memorized scriptures found.");
        }
    }
}
