public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {

    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded progress for '{_shortName}'. You earned {_points} points.");
    }
    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal, {base.GetStringRepresentation()}";
    }

    public override string GetGoalType()
    {
        return "EternalGoal";
    }
}