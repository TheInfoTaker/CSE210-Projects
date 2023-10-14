using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public int GetUserScore()
{
    int score = 0;

    // foreach (Goal goal in goals)
    // {
    //     if (goal.IsComplete())
    //     {
    //         score += goal.GetPoints();
    //     }
    // }

    return score;
}


    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"You have {score} points!");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("\nSelect an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoals();
                    break;

                case "3":
                    SaveGoals();
                    break;

                case "4":
                    LoadGoals();
                    break;

                case "5":
                    RecordEvent();
                    break;

                case "6":
                    Console.WriteLine("Quitting...");
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:\n");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("\nWhich type of goal would you like to create? ");

        string type = Console.ReadLine();

        switch (type)
        {
            case "1":
                CreateSimpleGoal();
                break;

            case "2":
                CreateEternalGoal();
                break;

            case "3":
                CreateChecklistGoal();
                break;

            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
    }

    public void CreateSimpleGoal()
    {
        var (name, desc, _points) = Goal.GetGoalDesc();
        var points = Goal.Conversion(_points);

        SimpleGoal goal = new SimpleGoal(name, desc, points);
        goals.Add(goal);
    }

    public void CreateEternalGoal()
    {
        var (name, desc, _points) = Goal.GetGoalDesc();
        var points = Goal.Conversion(_points);

        EternalGoal goal = new EternalGoal(name, desc, points);
        goals.Add(goal);
    }

    public void CreateChecklistGoal()
    {
        var (name, desc, _points) = Goal.GetGoalDesc();
        var points = Goal.Conversion(_points);

        Console.WriteLine("How many times does this need to be accomplished for a bonus?");
        int target = int.Parse(Console.ReadLine());

        Console.WriteLine("What is the bonus for accomplishing it that many times?");
        int bonus = int.Parse(Console.ReadLine());

        ChecklistGoal goal = new ChecklistGoal(name, desc, points, target, bonus);
        goals.Add(goal);
    }

    public void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to record events for.");
            return;
        }

        Console.WriteLine("Select a goal to record an event for:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }

        Console.Write("Enter the goal number: ");
        int goalNumber = int.Parse(Console.ReadLine());

        if (goalNumber >= 1 && goalNumber <= goals.Count)
        {
            Goal goal = goals[goalNumber - 1];
            goal.RecordEvent();
            if (goal is ChecklistGoal checklistGoal)
            {
                score += checklistGoal.GetPointsEarned();
            }
            Console.WriteLine("Event recorded!");
        }

        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("List of Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
            if (goals[i].IsComplete())
            {
                Console.WriteLine("[X] - Goal Completed");
            }
            else
            {
                Console.WriteLine("[ ] - Goal Incomplete");
            }
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter a filename to save your goals: ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = File.CreateText(fileName))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals have been saved!");
        // Goal.Loading();
    }

    public void LoadGoals()
    {
        Console.Write("Enter a filename to load your goals: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            goals.Clear();
            using (StreamReader reader = File.OpenText(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 3)
                    {
                        string name = parts[0];
                        string desc = parts[1];
                        int points = int.Parse(parts[2]);
                        int amountCompleted = parts.Length > 3 ? int.Parse(parts[3]) : 0;
                        int target = parts.Length > 4 ? int.Parse(parts[4]) : 0;
                        int bonus = parts.Length > 5 ? int.Parse(parts[5]) : 0;

                        if (amountCompleted > 0 && target > 0)
                        {
                            ChecklistGoal goal = new ChecklistGoal(name, desc, points, target, bonus);
                            goal.SetAmountCompleted(amountCompleted);
                            goals.Add(goal);
                        }
                        else if (amountCompleted == 0)
                        {
                            if (target > 0)
                            {
                                ChecklistGoal goal = new ChecklistGoal(name, desc, points, target, bonus);
                                goals.Add(goal);
                            }
                            else
                            {
                                SimpleGoal goal = new SimpleGoal(name, desc, points);
                                goals.Add(goal);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Goals have been loaded!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
