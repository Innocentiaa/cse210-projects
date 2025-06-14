public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus)
     : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted < _target)
        {
            Console.WriteLine($"Progress made for '{_shortName}'! {_amountCompleted}/{_target} completed.");
        }
        else if (_amountCompleted == _target)
        {
            Console.WriteLine($"Goal '{_shortName}' completed! You earned {_points + _bonus} points");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted>= _target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} (Completed {_amountCompleted}/{_target})";

    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal, {base.GetStringRepresentation()}, {_amountCompleted}, {_target}, {_bonus}";
    }

    public override string GetGoalType()
    {
        return "ChecklistGoal";
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }



}