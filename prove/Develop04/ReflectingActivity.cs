using System;
using System.Collections.Generic;

class ReflectingActivity
{

    List<string> countdown = new List<string>
    {
        "3",
        "2",
        "1",
    };

    List<string> prompts2 = new List<string>
    {
        "How did that experience make you feel?",
        "What did you learn from that experience?",
        "Would you do things differently next time?",
    };

    List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    public static void Reflect()
    {
        Console.WriteLine("Welcome to the Reflecting Activity.\n");
        Console.WriteLine("This activity will help you reflect on times when you have shown strength and resilience.");
        Console.WriteLine("The goal is to help you recognize your own strength to overcome obsticals in your life.\n");
        Console.WriteLine("How lonng would you like your session to be?: ");

        string inputStr = Console.ReadLine();

        if (int.TryParse(inputStr, out int input))
        {
            Console.WriteLine("One Moment...");
            Activity.Loading();

            ReflectingActivity activity = new ReflectingActivity();
            string randomPrompt = activity.GetRandomPrompt();

            Console.WriteLine("Consider the Following prompt\n");
            Console.WriteLine(randomPrompt);
            Console.WriteLine("\nWhen you have something in mind, press enter.");

            Console.ReadLine();

            Console.WriteLine("\nNow ponder each of the following questions as the related to this experience.");

            Console.WriteLine("\nBegin in:");

            foreach (string a in activity.countdown)
                {
                    Console.Write(a);
                    Thread.Sleep(1000);
                    Console.Write("\b \b");
                }

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(input);

            while (DateTime.Now < endTime)
            {
                string randomPrompt2 = activity.GetRandomPrompt();

                Console.WriteLine(randomPrompt2);
                Activity.Loading();
                Thread.Sleep(15000);
            }

            Console.WriteLine("Well Done!");
            Activity.Loading();
            Console.WriteLine("You have comleted this activity!");
            Activity.Loading();
        }
    }
    private string GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, prompts.Count);
        return prompts[randomIndex];
    }
     private string GetRandomPrompt2()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, prompts2.Count);
        return prompts2[randomIndex];
    }
}