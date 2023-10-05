using System;

class ListingActivity
{
        List<string> prompts = new List<string>
    {
        "When have you felt the Holy Ghost this month?",
        "When was the last time you felt the spirit?",
        "When did you pray last?",
        "When did you read the scriptures last?"
    };

    List<string> countdown = new List<string>
    {
        "3",
        "2",
        "1",
    };
    public static void listing()
    {
        Console.WriteLine("Welcome to the Listing Activity");
        Console.WriteLine("\nThis activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine("\nHow long in seconds, would you like for your session?");

        string inputStr = Console.ReadLine();

        if (int.TryParse(inputStr, out int input))
        {
            Console.WriteLine("One Moment...");
            Activity.Loading();

            ListingActivity activity = new ListingActivity();
            string randomPrompt = activity.GetRandomPrompt();

            Console.WriteLine("List as many responses as you can think of to the following prompt:\n");
            Console.WriteLine(randomPrompt);
            Console.WriteLine("\nBegin in:");


            foreach (string a in activity.countdown)
                {
                    Console.Write(a);
                    Thread.Sleep(1000);
                    Console.Write("\b \b");
                }

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(input);

            int iterations = 0;

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                Console.ReadLine();
                iterations += 1;
            }
            Console.WriteLine($"\nYou wrote {iterations} answers!");

            Console.WriteLine("\nWell Done!");
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
}