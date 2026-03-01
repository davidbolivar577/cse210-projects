using System;
using System.Formats.Asn1;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Activity test;
        Console.Clear();
        //choose activity
        Console.WriteLine("Options:");
        Console.WriteLine("1: Breathing Activity");
        Console.WriteLine("2: Reflection Activity");
        Console.WriteLine("3: Listening Activity");
        Console.Write("\nChoose your activity: ");
        string choice = Console.ReadLine();
        Console.Clear();
        if(choice == "")
        {
            test = new Activity();
        }
        else if(choice.ToLower()[0] =='b' || int.TryParse(choice, out int a) && int.Parse(choice) == 1)
        {
            test = new BreathingActivity();
        }
        else if(choice.ToLower()[0] == 'r' || int.TryParse(choice, out int b) && int.Parse(choice) == 2)
        {
            test = new ReflectionActivity();
        }
        else if(choice.ToLower()[0] == 'l' || int.TryParse(choice, out int c) && int.Parse(choice) == 3)
        {
            test = new ListeningActivity();
        }
        else
        {
            test = new Activity();
        }
        
        test.Run();
    }
}