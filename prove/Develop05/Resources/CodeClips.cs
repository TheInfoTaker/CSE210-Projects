
// // Read Txt
// class Program
// {
//     static void Main(string[] args)
//     {
//         string fileName = "goals.txt"; // Specify the file name

//         List<string> goalLines = new List<string>();

//         if (File.Exists(fileName))
//         {
//             goalLines = File.ReadAllLines(fileName).ToList();
//         }
//         else
//         {
//             Console.WriteLine("File not found.");
//         }

//         foreach (string line in goalLines)
//         {
//             string[] parts = line.Split(':'); // Split the line by ':'

//             if (parts.Length == 4)
//             {
//                 string goalType = parts[0];
//                 string goalName = parts[1];
//                 string description = parts[2];
//                 int points = int.Parse(parts[3]);
//                 bool isChecked = bool.Parse(parts[4]);

//                 // Create goals or do something with the data as needed
//                 // Example: CreateGoal(goalType, goalName, description, points, isChecked);
//             }
//         }
//     }
// }

// // Txt format

// class Program
// {
//     static void Main(string[] args)
//     {
//         string fileName = "goals.txt"; // Specify the file name

//         // Sample goal data
//         string goalType = "SimpleGoal";
//         string goalName = "Give a talk";
//         string description = "Speak in Sacrament Meeting";
//         int points = 100;
//         bool isChecked = false;

//         // Construct the data line
//         string goalLine = $"{goalType}:{goalName},{description},{points},{isChecked}";

//         // Write the goal data to the file
//         using (StreamWriter writer = File.AppendText(fileName))
//         {
//             writer.WriteLine(goalLine);
//         }

//         Console.WriteLine("Goal data written to the file.");
//     }
// }

// // Goal Description

// class Goal
// {
//     public static void GoalDescription()
//     {
//         Console.WriteLine("What is the name of your goal?");
//         string name = Console.ReadLine();

//         Console.WriteLine("What is a short description of it?");
//         string description = Console.ReadLine();

//         Console.WriteLine("What is the number of points associated with the goal?");
//         if (int.TryParse(Console.ReadLine(), out int points))
//         {
//             Console.WriteLine($"Goal Name: {name}");
//             Console.WriteLine($"Description: {description}");
//             Console.WriteLine($"Points: {points}");
//         }
//         else
//         {
//             Console.WriteLine("Invalid points value. Please enter a valid number.");
//         }
//     }
// }

//     // public static int Conversion()
//     // {
//     //     int points = Goal.GoalDescription(none, none, _points);
//     //     return points;
//     // } 