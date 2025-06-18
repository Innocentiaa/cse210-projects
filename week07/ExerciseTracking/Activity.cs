using System;

public abstract class Activity
{
    private string _date;
    private int _duration;

    protected Activity(string date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public string Date => _date;
    public int Duration => _duration;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date} ({Duration} min)";
    }

}