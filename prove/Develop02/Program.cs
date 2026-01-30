using System;

class Program
{
    public static Journal current = new();
    public static List<string> prompts = [
        "What is one good thing that happened today?",
        "Did someone make your day better?",
        "What was a small victory of the day?",
        "What was the most difficult part of today?",
        "What is one thing from today that you want to improve tomorrow?",
        "What is something you learned today?",
        "Were you able to teach someone today?"
    ];
    public static Random rand = new();
    public static List<int> sessionPrompts = [];

    static void Write()
    {
        int next;
        do
        {
            if(sessionPrompts.Count == prompts.Count)
            {
                sessionPrompts = [];
            }
            next = rand.Next(prompts.Count);
            Console.WriteLine("Loop in do"); //debug
        }while(sessionPrompts.Contains(next));
        sessionPrompts.Add(next);

        string prompt = prompts[next];
        Console.WriteLine(prompt);
        string answer = Console.ReadLine();
        current.entries.Add(new Entry(prompt, answer));
    }

    static void Load()
    {
        Console.Write("Enter your filename: ");
        current = Journal.Load($"{Console.ReadLine()}.csv");
        sessionPrompts = [];
    }

    static void Save()
    {
        Console.Write("Enter your filename: ");
        current.Save($"{Console.ReadLine()}.csv");
    }

    static void Main(string[] args)
    {
        bool cont = true;
        string choice = "";
        Console.WriteLine("Welcome to Journal Program!");
        do{
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do?: ");
            choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Write();
                    break;
                
                case "2":
                    current.Display();
                    break;
                
                case "3":
                    Load();
                    break;
                
                case "4":
                    Save();
                    break;
                
                case "5":
                    cont = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }while(cont);
    }
}