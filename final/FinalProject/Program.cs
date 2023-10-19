using System;
using System.Collections.Generic;

class Activity
{
    private DateTime Date { get; set; }
    protected int Minutes { get; set; }

    public Activity(DateTime date, int minutes)
    {
        Date = date;
        Minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Base class does not have distance information
    }

    public virtual double GetSpeed()
    {
        return 0; // Base class does not have speed information
    }

    public virtual double GetPace()
    {
        return 0; // Base class does not have pace information
    }

    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy}: {GetActivityType()} ({Minutes} min)";
    }

    public virtual string GetActivityType()
    {
        return "Activity";
    }
}

class Running : Activity
{
    private double Distance { get; set; }

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return Distance / (Minutes / 60.0);
    }

    public override double GetPace()
    {
        return Minutes / Distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}: Distance {Distance:F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }

    public override string GetActivityType()
    {
        return "Running";
    }
}

class StationaryBicycle : Activity
{
    private double Speed { get; set; }

    public StationaryBicycle(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        Speed = speed;
    }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetDistance()
    {
        return (Speed * Minutes) / 60.0;
    }

    public override double GetPace()
    {
        return 60.0 / Speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}: Speed {Speed:F1} kph, Distance {GetDistance():F1} km, Pace: {GetPace():F1} min per km";
    }

    public override string GetActivityType()
    {
        return "Stationary Bicycle";
    }
}

class Swimming : Activity
{
    private int Laps { get; set; }

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return (Laps * 50) / 1000.0; // Convert 50m laps to kilometers
    }

    public override double GetSpeed()
    {
        return GetDistance() / (Minutes / 60.0);
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}: Distance {GetDistance():F1} km, Speed {GetSpeed():F1} kph, Pace: {GetPace():F1} min per km";
    }

    public override string GetActivityType()
    {
        return "Swimming";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Create activities of each type
        Activity runningActivity = new Running(DateTime.Now, 30, 3.0);
        Activity bicycleActivity = new StationaryBicycle(DateTime.Now, 45, 20.0);
        Activity swimmingActivity = new Swimming(DateTime.Now, 60, 40);

        activities.Add(runningActivity);
        activities.Add(bicycleActivity);
        activities.Add(swimmingActivity);

        // Display summary for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
