using System;
using System.ComponentModel;
using System.ComponentModel;

class Program
{
    private static List<Scripture> scriptures = [];
    private static Scripture challenge;

    private static List<Scripture> scriptures = [];
    private static Scripture challenge;

    static void Main(string[] args)
    {
        GetScriptures();

        Random rand = new();
        challenge = scriptures[rand.Next(scriptures.Count)];

        bool cont = true;
        do
        {
            Console.Clear();
            Console.WriteLine(challenge.Display());

            Console.Write("\nPress enter to continue or type 'quit' to finish: ");
            string choice = Console.ReadLine();
            if (choice.Length > 0)
            {
                choice = choice[0..1].ToLower();
            }
            if (choice == "q")
            {
                cont = false;
            }
            else
            {
                cont = !challenge.AllHidden();
            }
            challenge.HideBatch();
        } while (cont);
    }

    static void GetScriptures()
    {
        string[] lines = System.IO.File.ReadAllLines("Scriptures.txt");
        foreach (string line in lines)
        {
            List<string> input = new(line.Split('$'));
            scriptures.Add(new Scripture(input[0], input[1]));
        }
    }


}