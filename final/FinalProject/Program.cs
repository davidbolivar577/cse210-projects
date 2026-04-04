using System;

class Program
{
    private static Config config = null;
    private static Report report = null;
    static void Main(string[] args)
    {
        //main menu
        bool cont = false;//DEBUG::implement choices::set true
        string choice = "";
        Console.WriteLine("Welcome to War Simulator");
        do
        {

            config = new(2, new(), 5);
            Run();
            Run();
            report.Display();
            /*TODO Options
            Console.WriteLine("Please select one of the following choices:");
            //Console.WriteLine("?. Exit");//TODO Options
            Console.Write("What would you like to do?: ");
            choice = Console.ReadLine().ToLower();
            if (choice != "")
            {
                
                Console.Clear();
                switch (choice[0])
                {
                    case '1' or 'd':
                        DisplayAll();
                        break;

                    case '2' or 'c':
                        Create();
                        break;

                    case '3' or 'u':
                        Update();
                        break;
                    case '4' or 's':
                        Save();
                        break;
                    case '5' or 'l':
                        Load();
                        break;
                    case '6' or 'e':
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            else
            {
                //DEBUG::testing area

                /*DEBUG::implement choices::uncomment
                Console.Clear();
                Console.WriteLine("Invalid choice. Try again.");
                
            }
            */
        } while (cont);
    }

    public static void ConfigSet()
    {

    }

    public static void ConfigSave()
    {

    }

    public static void LoadConfig()
    {

    }

    public static void Run()
    {
        Simulator sim = new(config);
        sim.Run();
        if (report is null)
        {
            report = sim.Export();
        }
        else
        {
            report.Append(sim.Export());
        }
    }

    public static void ReportView()
    {
        report.Display();
    }

    public static void ReportSave()
    {

    }

    public static void ReportLoad()
    {

    }
}