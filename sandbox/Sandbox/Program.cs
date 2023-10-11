using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int result = 0;
        string fileName = "previous_rolls.txt";

        Console.WriteLine("Welcome to the Random Number Generator!");
        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Coin Flip");
            Console.WriteLine("2. Three-Sided Dice");
            Console.WriteLine("3. Six-Sided Dice");
            Console.WriteLine("4. Twenty-Sided Dice");
            Console.WriteLine("5. Load Previous Rolls");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        result = random.Next(2); // 0 for heads, 1 for tails
                        Console.WriteLine(result == 0 ? "Heads" : "Tails");
                        break;
                    case 2:
                        result = random.Next(1, 4); // 1, 2, or 3
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 3:
                        result = random.Next(1, 7); // 1 to 6
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 4:
                        result = random.Next(1, 21); // 1 to 20
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 5:
                        LoadPreviousRolls(fileName);
                        Console.Write("Press enter to continue:");
                        Console.ReadLine();
                        continue;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        continue;
                }

                SavePrompt(result, fileName);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    public static void SavePrompt(int result, string fileName)
    {
        Console.Write("Do you want to save this roll? (Y/N): ");
        string saveChoice = Console.ReadLine();
        if (saveChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            SaveRoll(fileName, result);
        }
    }

    public static void SaveRoll(string fileName, int result)
    {
        using (StreamWriter writer = File.AppendText(fileName))
        {
            writer.WriteLine(result);
            Console.WriteLine("Result saved successfully!");
        }
    }

    public static void LoadPreviousRolls(string fileName)
    {
        if (File.Exists(fileName))
        {
            List<int> rolls = new List<int>();
            using (StreamReader reader = File.OpenText(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int roll))
                    {
                        rolls.Add(roll);
                    }
                }
            }

            if (rolls.Count > 0)
            {
                Console.WriteLine("Previous Rolls:");
                foreach (int roll in rolls)
                {
                    Console.WriteLine(roll);
                }
            }
            else
            {
                Console.WriteLine("No previous rolls found.");
            }
        }
        else
        {
            Console.WriteLine("No previous rolls found.");
        }
    }
}
