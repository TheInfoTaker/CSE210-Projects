using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string fileName = "";
        ProvidePrompt providePrompt = new ProvidePrompt();

        while (true)
        {
            string choice = Menu.Choice();

            switch (choice)
            {
                case "1":
                    string randomPrompt = providePrompt.ProvideRandomPrompt();
                    Console.WriteLine($"Prompt: {randomPrompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    Journal.AddEntry(randomPrompt, response);
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        journal.SaveToFile(fileName);
                    }
                    else
                    {
                        Console.Write("Enter a file name to save: ");
                        fileName = Console.ReadLine();
                        journal.SaveToFile(fileName);
                    }
                    break;

                case "4":
                    Console.Write("Enter a file name to load: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;

                case "5":
                    Console.WriteLine("Goodbye");
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

        }
    }
}