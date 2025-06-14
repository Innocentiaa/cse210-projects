public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetPoints()
    {
        return _points;
    }

    public abstract string GetGoalType();


    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"{_shortName}, - {_description}";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{_shortName}, {_description}, {_points}";
    }

}