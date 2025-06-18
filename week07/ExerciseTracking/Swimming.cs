public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0 * 0.62;
    public override double GetSpeed() => (GetDistance() / Duration) * 60;

    public override double GetPace() => Duration / GetDistance();

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Swimming - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph. Pace: {GetPace()} minute per mile";
    }


}