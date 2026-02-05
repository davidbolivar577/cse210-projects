using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac1 = new();
        Fraction frac2 = new(6);
        Fraction frac3 = new(6, 7);
        Console.WriteLine(frac1.GetTop());
        Console.WriteLine(frac1.GetBottom());
        Console.WriteLine(frac1.GetFractionalString());

        frac1.SetBottom(9);
        Console.WriteLine(frac1.GetFractionalString());
        frac1.SetTop(4);
        Console.WriteLine(frac1.GetFractionalString());

        Console.WriteLine(frac1.GetTop());
        Console.WriteLine(frac1.GetBottom());


        Fraction frac = new();
        Random r = new();
        for (int i = 0; i < 30; i++)
        {
            int t = r.Next(100);
            int b = r.Next(100);

            frac.SetTop(t);
            frac.SetBottom(b);

            Console.WriteLine($"Fraction {i + 1}: string: {frac.GetFractionalString()} Number: {frac.GetDecimalValue()}");
        }
    }
}