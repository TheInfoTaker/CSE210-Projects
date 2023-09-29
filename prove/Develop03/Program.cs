using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Scripture Memorizer");

        string referenceText = "John 8:16";
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

        Scripture scripture = new Scripture(referenceText, scriptureText);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine("-------------------");
            //INSPECT
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to remove random words or type quit to exit: ");
            string input = Console.ReadLine();
            //INSPECT
            if (input.ToLower() == "quit")
            {
                break;
            }
            //INSPECT
            scripture.HideRandomWords(3);

            //INSPECT
            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("The words in the scipture are completely hidden.");
                break;
            }
        }

        Console.WriteLine("Thanks for using this Scripture Memorizer program!");
    }
}
