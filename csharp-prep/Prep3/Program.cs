using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        int guesses = 1;

        while (guess != magicNumber)
        {
            Console.Write("Enter your guess: ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
                guesses = guesses + 1;
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
                guesses = guesses + 1;
            } 
            else
            {
                Console.WriteLine($"That's it! You made {guesses} guesses.");
                string guesses2 = guesses.ToString();
                Console.WriteLine($"You guessed {guesses2} times.");
            }
        }
    }
}