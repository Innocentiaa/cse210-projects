using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private List<string> _badges = new List<string>();
    private int _currentLevel = 0;

    public GoalManager()
    {
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Goal Manager!");      
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player's Score: {_score}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Detailed Goals Information: ");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStringRepresentation());
        }
    }

    public void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
        Console.WriteLine("Goal added successfully!");
    }

    public void RecordEvent(string _shortName )
    {
        foreach (var goal in _goals)
        {
            if (goal.GetDetailsString().Contains(_shortName))
            {
                goal.RecordEvent();
                _score += int.Parse(goal.GetPoints());
                Console.WriteLine($"Event recorded for {_shortName}");
                return;
            }
        }
        Console.WriteLine("Goal not found.");
    }
    
    private void AwardBadge(string badgeName)
    {
        Console.WriteLine($"🎉 You earned a badge: {badgeName}! Keep it up!");
        _badges.Add(badgeName);
    }

    public void CheckLevelUp()
    {
        int level = _score / 1000;
        if (level > _currentLevel)
        {
            _currentLevel = level;
            Console.WriteLine($"Congratulations! You leveled up to Level {_currentLevel}!");

            AwardBadge($"Level {_currentLevel} Achieved");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Goals saved successfully to {filename}");
    }

    public void LoadGoals(string filename = "goals.txt")
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {

            var parts = line.Split(',');

            if (parts.Length < 4) continue;

            string type = parts[0].Trim();
            string name = parts[1].Trim();
            string description = parts[2].Trim();
            string points = parts[3].Trim();

            Goal goal = null;

            if (type == "SimpleGoal" || type == "EternalGoal")
            {
                if (type == "SimpleGoal")
                    goal = new SimpleGoal(name, description, points);
                else if (type == "EternalGoal")
                    goal = new EternalGoal(name, description, points);
            }
            else if (type == "ChecklistGoal")
            {
                if (parts.Length < 7) continue; 

                
                int amountCompleted = int.Parse(parts[4].Trim());
                int target = int.Parse(parts[5].Trim());
                int bonus = int.Parse(parts[6].Trim());

                var checklistGoal = new ChecklistGoal(name, description, points, target, bonus);


                checklistGoal.SetAmountCompleted(amountCompleted);

                goal = checklistGoal;
            }

            if (goal != null)
                _goals.Add(goal);
        }

        Console.WriteLine("Goals loaded successfully.");
    }



}