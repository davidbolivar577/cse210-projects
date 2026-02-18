using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new("David 1", "Factoring");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment assignment2 = new("David 2", "Calculus", "5.2", "1-17");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());

        WritingAssignment assignment3 = new("David 3", "Biology", "The ATP Cycle");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}