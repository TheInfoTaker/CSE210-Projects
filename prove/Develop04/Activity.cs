using System;
using System.Security.Cryptography.X509Certificates;

class Activity
{

    private int _time;

    public Activity(int time)
    {
        _time = time;
    }
    public static void Loading()
    {
        List<string> loadingStrings = new List<string>();
        loadingStrings.Add("|");
        loadingStrings.Add("/");
        loadingStrings.Add("-");
        loadingStrings.Add("\\");
        loadingStrings.Add("|");
        loadingStrings.Add("/");
        loadingStrings.Add("-");
        loadingStrings.Add("\\");

    // Console.WriteLine("One Moment...");

        foreach (string s in loadingStrings)
        {
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
    }
        public int Duration()
    {
        Console.WriteLine("In seconds, how long would you like to participate in this exercise?:");
        
        string inputStr = Console.ReadLine();

        if (int.TryParse(inputStr, out int input))
        {
            return input;
        }
        else
        {
            Console.WriteLine("Invalid Entry");
            return 0;
        }
    }
}
