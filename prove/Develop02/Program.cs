using System;

class Program
{
    public static Journal current = new();
    public List<String> prompts = [];

    static void Write()
    {
        //give prompt
        //receive answer
        //add entry
    }

    static void Load()
    {
        Console.Write("Enter your filename: ");
        current = Journal.Load($"{Console.ReadLine()}.csv");
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