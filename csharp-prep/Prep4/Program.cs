using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        bool answer = true;
        List<int> input = new List<int>();
        do
        {
            Console.Write("Enter a number: ");
            int next = int.Parse(Console.ReadLine());
            if (next == 0)
            {
                answer = false;
            }
            else
            {
                input.Add(next);
            }

        }
        while (answer);
        int sum = 0;
        int max = 0;
        int smallPos = 0;
        foreach (int i in input)
        {
            sum += i;
            if (max == 0)
            {
                max = i;
            }
            else if (i > max)
            {
                max = i;
            }
            if (i > 0)
            {
                if (smallPos == 0)
                {
                    smallPos = i;
                }
                else if (i < smallPos)
                {
                    smallPos = i;
                }
            }
        }
        input.Sort();
        double average = (double)sum / input.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {smallPos}");
        Console.WriteLine("This is the sorted list:");
        foreach (int p in input)
        {
            Console.WriteLine(p);
        }
    }
}