using System;

class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }
    

        public static (string, string, string) GetGoalDesc()
    {
        Console.WriteLine("What is the name of your goal?");
        string name = Console.ReadLine();

        Console.WriteLine("What is a short description of if?");
        string desc = Console.ReadLine();

        Console.WriteLine("What is the number of points associated with the goal?");
        string _points = Console.ReadLine();

        return (name, desc, _points);
    }

    //For use in all goals
public static int Conversion(string _points)
{
    if (int.TryParse(_points, out int points))
    {
        return points;
    }
    else
    {
        Console.WriteLine("Invalid points value. Please enter a valid number.");
        return 0;
    }
}

    public virtual void RecordEvent()
    {

    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description}) Points: {_points}";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points}";
    }
}

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return base.GetStringRepresentation();
    }

    //     public override int GetPoints()
    // {
    //     return _points;
    // }
}

class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points){}

    public override string GetStringRepresentation()
    {
        return base.GetStringRepresentation();
    }
}

class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
        
    }

    public override void RecordEvent()
    {
        _amountCompleted++;

        if (_amountCompleted == _target)
        {
            _points += _bonus;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} ({_description}) Points: {_points} Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return base.GetStringRepresentation() + $",{_amountCompleted},{_target},{_bonus}";
    }

public static (string name, string description, int points) GetGoalDesc()
{
    Console.Write("Enter the goal name: ");
    string name = Console.ReadLine();

    Console.Write("Enter the goal description: ");
    string description = Console.ReadLine();

    Console.Write("Enter the goal points: ");
    int points;
    if (!int.TryParse(Console.ReadLine(), out points))
    {
        Console.WriteLine("Invalid input for points. Defaulting to 0.");
        points = 0;
    }

    return (name, description, points);
}

public void SetAmountCompleted(int amountCompleted)
{
    _amountCompleted = amountCompleted;
}

public int GetPointsEarned()
{
    int pointsEarned = _points;

    if (_amountCompleted >= _target)
    {
        pointsEarned += _bonus;
    }

    return pointsEarned;
}

 public virtual int GetPoints()
    {
        // Default implementation, you can return a default value
        return 0;
    }

}


