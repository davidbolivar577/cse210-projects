using System;
using System.Text.Json;

class Program
{
    private static Config config = null;
    private static Report report = null;

    private static string defaultConfig = "war.config";
    private static string defaultReport = "war.report";

    static void Main(string[] args)
    {
        //main menu
        bool cont = true;
        string choice = "";
        Console.WriteLine("Welcome to War Simulator");
        do
        {
            Console.WriteLine("Main Menu\n");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Config Menu\n2. Simulator\n3. Report Menu\n4. Exit");
            Console.Write("What would you like to do?: ");
            choice = Console.ReadLine().ToLower();
            if (choice != "")
            {

                Console.Clear();
                switch (choice[0])
                {
                    case '1' or 'c':
                        ConfigMenu();
                        break;

                    case '2' or 's':
                        Run();
                        break;

                    case '3' or 'r':
                        ReportMenu();
                        break;
                    case '4' or 'e':
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid choice. Try again.");

            }
        } while (cont);
    }

    //menus
    public static void ConfigMenu()
    {
        bool invalid = false;
        Console.WriteLine("Configuration Menu:");
        Console.WriteLine("1. Create Configuration\n2. Save Configuration\n3. Load Configuration.\n4. Exit");
        Console.Write(": ");
        do
        {
            string choice = Console.ReadLine().ToLower();
            if (choice != "")
            {
                invalid = false;
                Console.Clear();
                switch (choice[0])
                {
                    case '1' or 'c':
                        ConfigSet();
                        return;
                    case '2' or 's':
                        ConfigSave();
                        return;
                    case '3' or 'l':
                        ConfigLoad();
                        return;
                    case '4' or 'e':
                        return;
                    
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        invalid = true;
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid choice. Try again.");
                invalid = true;
            }
        } while (invalid);
    }
    public static void ReportMenu()
    {
        bool invalid = false;
        Console.WriteLine("Report Menu:");
        Console.WriteLine("1. View Report\n2. Save Report\n3. Load Report.\n4. Exit");
        Console.Write(": ");
        do
        {
            string choice = Console.ReadLine().ToLower();
            if (choice != "")
            {
                invalid = false;
                Console.Clear();
                switch (choice[0])
                {
                    case '1' or 'v':
                        ReportView();
                        return;
                    case '2' or 's':
                        ReportSave();
                        return;
                    case '3' or 'l':
                        ReportLoad();
                        return;
                    case '4' or 'e':
                        return;
                    
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        invalid = true;
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid choice. Try again.");
                invalid = true;
            }
        } while (invalid);
    }

    //submenus
    public static void ConfigSet()
    {
        //TODO
    }

    public static void ConfigSave()
    {
        if(config is null)
        {
            Console.WriteLine("There is no configuration to save");
            return;
        }
        else
        {
            Console.Write("Enter file name to save as: ");
            string filename = Console.ReadLine();
            if(filename == "")
            {
                Console.WriteLine($"Using default {defaultConfig}");
                filename = defaultConfig;
            }

            using (StreamWriter outputFile = new(filename))
            {
                outputFile.WriteLine(config.Save());
                Console.WriteLine("Configuration saved");
            }
        }
    }

    public static void ConfigLoad()
    {
        Console.Write("Configuration filename: ");
        string filename = Console.ReadLine();
        if(filename == "")
            {
                Console.WriteLine($"Using default {defaultConfig}");
                filename = defaultConfig;
            }
        string f = System.IO.File.ReadAllLines(filename)[0];
        config = JsonSerializer.Deserialize<Config>(f);
        Console.WriteLine("Configuration loaded");
    }
    public static void Run()
    {
        Simulator sim;
        if (config is null)
        {
            Console.WriteLine("No configuration detected. Using default configuration...");
            config = new(2, new(), 10);
        }
        sim = new(config);
        sim.Run();
        if (report is null)
        {
            report = sim.Export();
        }
        else
        {
            report.Append(sim.Export());
        }
        Console.WriteLine("Simulation complete. Results have been sent to your report.");
    }

    public static void ReportView()//TODO
    {
        report.Display();
    }

    public static void ReportSave()
    {
        if(report is null)
        {
            Console.WriteLine("There is no report to save");
            return;
        }
        else
        {
            Console.Write("Enter file name to save as: ");
            string filename = Console.ReadLine();
            if(filename == "")
            {
                Console.WriteLine($"Using default {defaultReport}");
                filename = defaultReport;
            }

            using (StreamWriter outputFile = new(filename))
            {
                outputFile.WriteLine(report.Save());
                Console.WriteLine("Report saved");
            }
        }
    }

    public static void ReportLoad()//TODO
    {
        //take file name, default to war.report
        Console.WriteLine();
    }
}