public class Running : Activity
{
    private double _distance;

    public Running(string date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (_distance / Duration) * 60;

    public override double GetPace() => Duration / _distance;

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Running - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph. Pace: {GetPace()} minute per mile";
    }

}