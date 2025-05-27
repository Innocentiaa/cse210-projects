using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide)
        {
            var candidates = _words.Where(word => !word.IsHidden()).ToList();
            if (candidates.Count == 0) break;

            int index = random.Next(candidates.Count);
            candidates[index].Hide();
            hiddenCount++;
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()}: {scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public string GetReferenceText()
    {
        return _reference.GetDisplayText();
    }

    public string GetScriptureText()
    {
        return string.Join(" ", _words.Select(word => word.GetDisplayText()));
    }
}
