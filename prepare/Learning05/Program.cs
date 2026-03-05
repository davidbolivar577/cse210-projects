using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = [];
        shapes.Add(new Square("blue", 4.5));
        shapes.Add(new Rectangle("red", 4, 5));
        shapes.Add(new Circle("yellow", 4.5));

        foreach (Shape s in shapes)
        {
            Console.WriteLine(s.GetColor());
            Console.WriteLine(s.GetArea());
            Console.WriteLine();
        }
    }
}