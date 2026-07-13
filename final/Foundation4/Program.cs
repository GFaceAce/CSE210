using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("01 Apr 2020", 120, 4.0),
            new Cycling("04 May 1976", 45, 15.0),
            new Swimming("28 Feb 2099", 40, 40)
        };
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}