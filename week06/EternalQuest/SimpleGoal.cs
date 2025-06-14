public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal( string name, string description, string points) : base(name, description,points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Goal '{_shortName}' completed! You earned {_points} points.");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal, {base.GetStringRepresentation()}, {_isComplete}";
    }

    public override string GetGoalType()
    {
        return "SimpleGoal";
    }
}