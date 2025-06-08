using System;
public class BreathingActivity : Activity
{

    private Log _log;


    public BreathingActivity(Log log) : base("Breathing", "This activity helps you relax by focusing on deep breathing.")
    {
        _log = log;
    }

    public void Run()
    {
        DisplayStartingMessage();
        for (int i = 0; i < _duration / 6; i++)
        {
            Console.WriteLine("Breathe in ...");
            ShowSpinner(3);
            Console.WriteLine("Breathe out...");
            ShowSpinner(3);
        }
        _log.IncrementActivityCount("BreathingActivity");
        DisplayEndingMessage();
    }



}