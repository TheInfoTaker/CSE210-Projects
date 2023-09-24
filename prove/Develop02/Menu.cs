using System;

class Menue
{
    public void Display()
    {
        Console.WriteLine("1. Write New Entry");
        Console.WriteLine("2. Display Journal Entrys");
        Console.WriteLine("3. Save Journal");
        Console.WriteLine("4. Load Journal");
        Console.WriteLine("5. Quit");
        Console.WriteLine("");
        string Choice = Console.ReadLine();
    }
}