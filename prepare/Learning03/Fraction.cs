using System;
public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int top)
    {
        _numerator = top;
        _denominator = 1;
    }

    public Fraction(int top, int bottom)
    {
        if (bottom == 0)
        {
            throw new ArgumentException("You cannot devide by zero.");
        
        }

        _numerator = top;
        _denominator = bottom;
    }

    public int GetNumerator()
    {
        return _numerator;
    }

    public void SetNumerator(int value)
    {
        _numerator = value;
    }

    public int GetDenominator()
    {
        return _denominator;
    }

    public void SetDenominator(int value)
    {
        if (value != 0)
        {
            _denominator = value;
        }
    }

    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
        {
        return (double)_numerator / _denominator;
        }

    public override string ToString()
    {
        return $"{_numerator}/{_denominator}";
    }
}