using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(6);
        Fraction fraction3 = new Fraction(6, 7);

        Console.WriteLine("Fraction 1: " + fraction1);
        Console.WriteLine("Fraction 2: " + fraction2);
        Console.WriteLine("Fraction 3: " + fraction3);

        fraction1.SetNumerator(3);
        fraction1.SetDenominator(4);

        int _numeratorValue = fraction1.GetNumerator();
        int _denominatorValue = fraction1.GetDenominator();

        Console.WriteLine("\nUpdate:");
        Console.WriteLine($"Fraction 1: {fraction1}");
        Console.WriteLine($"Numerator: {_numeratorValue}");
        Console.WriteLine($"Denominator: {_denominatorValue} ");
    }
}