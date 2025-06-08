public class Log
{
    private Dictionary<string, int> _activityCounts;
    private List<string> _activityDetails;

    public Log()
    {
        _activityCounts = new Dictionary<string, int>
        {
            { "BreathingActivity", 0 },
            { "ListingActivity", 0 },
            { "ReflectingActivity", 0 }
        };
        _activityDetails = new List<string>();
    }

    public void IncrementActivityCount(string activityName)
    {
        if (_activityCounts.ContainsKey(activityName))
        {
            _activityCounts[activityName]++;
            _activityDetails.Add($"{activityName} performed at {DateTime.Now}");
        }
    }

    public void DisplaySummary()
    {
        Console.WriteLine("\n--- Session Summary ---");
        Console.WriteLine("Total activities performed: " + _activityDetails.Count);

        foreach (var activity in _activityCounts)
        {
            Console.WriteLine($"{activity.Key}: {activity.Value} time(s)");
        }

        Console.WriteLine("\nActivity Details:");
        foreach (var detail in _activityDetails)
        {
            Console.WriteLine(detail);
        }
    }
}
