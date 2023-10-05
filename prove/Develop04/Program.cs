using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Exercise");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listening Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Select an option:");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    BreathingActivity.BreathTimer();
                    break;

                case "2":
                    ReflectingActivity.Reflect();
                    break;

                case "3":
                    ListingActivity.listing();
                    break;

                case "4":
                    Console.WriteLine("We hope you find yourself more relaxed. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}