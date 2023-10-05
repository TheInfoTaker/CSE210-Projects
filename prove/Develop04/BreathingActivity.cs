using System;

class BreathingActivity
{

    private int _time;

    public BreathingActivity(int time)
    {
        _time = time;
    }

    public static void BreathTimer()
    {
        List<string> BreathIn = new List<string>();
        BreathIn.Add("4");
        BreathIn.Add("3");
        BreathIn.Add("2");
        BreathIn.Add("1");

        List<string> BreathOut = new List<string>();
        BreathOut.Add("6");
        BreathOut.Add("5");
        BreathOut.Add("4");
        BreathOut.Add("3");
        BreathOut.Add("2");
        BreathOut.Add("1");

        Console.WriteLine("Welcome to the Breathing Activity\n");
        Console.WriteLine("This activity is designed to help you relax by walking you through a breathing exercise.\nClear your mind and focus on your breathing.\n");
        Console.WriteLine("In seconds, how long would you like to participate in this exercise?: ");

        string inputStr = Console.ReadLine();

        if (int.TryParse(inputStr, out int input))
        {
            Console.WriteLine("One Moment...");
            Activity.Loading();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(input);

            while (DateTime.Now < endTime)
            {
                Console.WriteLine("\nBreath in...");
                
                foreach (string a in BreathIn)
                {
                    Console.Write(a);
                    Thread.Sleep(1000);
                    Console.Write("\b \b");
                }

                Console.WriteLine("Breath Out...");

                foreach (string b in BreathOut)
                {
                    Console.Write(b);
                    Thread.Sleep(1000);
                    Console.Write("\b \b");
                }
            }
        }
    }
}