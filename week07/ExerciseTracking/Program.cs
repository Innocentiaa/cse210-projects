using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");

        var activities = new List<Activity>
        {
            new Running("16 Jun 2025", 30, 3.0),
            new Cycling("16 Jun 2025", 45, 15.0),
            new Swimming("16 Jun 2025", 50, 30),
            new Running("17 Jun 2025", 25, 2.5),
            new Cycling("17 Jun 2025", 60, 20.0),
            new Swimming("17 Jun 2022", 30, 25)

        };



        var groupedActivities = activities.GroupBy(activity => activity.GetType().Name);

        foreach (var group in groupedActivities)
        {
            Console.WriteLine($"{group.Key} Activities:");
            foreach (var activity in group)
            {
                Console.WriteLine(activity.GetSummary());
            }
            Console.WriteLine("------------");
    }


    }
    
}