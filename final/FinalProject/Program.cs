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
        do
        {
            Console.Write(": ");
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
        do
        {
            Console.Write(": ");
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
        bool invalid = false;
        int p = -1;
        int g = -1;
        List<Card> cards = [];
        Console.WriteLine("Configuration Creator:");
        do
        {
            Console.Write("How many players should there be?: ");
            invalid = !int.TryParse(Console.ReadLine(), out p);
            if (invalid || p < 2)
            {
                Console.WriteLine("Invalid number. Try again");
                invalid = true;
            }
        } while (invalid);
        Console.WriteLine();
        do
        {
            Console.Write("How many games should be played?: ");
            invalid = !int.TryParse(Console.ReadLine(), out g);
            if (invalid || g < 1)
            {
                Console.WriteLine("Invalid number. Try again");
                invalid = true;
            }
        } while (invalid);

        Console.WriteLine("Guide: [value][suit]");
        Console.WriteLine("Valid values     Valid suits");
        Console.WriteLine("Two: 2           Spades: s");
        Console.WriteLine("Three: 3         Clubs: c");
        Console.WriteLine("four: 4          Diamonds: d");
        Console.WriteLine("Five: 5          Hearts: h");
        Console.WriteLine("Six: 6");
        Console.WriteLine("Seven: 7");
        Console.WriteLine("Eight: 8");
        Console.WriteLine("Nine: 9");
        Console.WriteLine("Ten: 10");
        Console.WriteLine("Jack: 11");
        Console.WriteLine("Queen: 12");
        Console.WriteLine("King: 13");
        Console.WriteLine("Ace: 14");
        Console.WriteLine("Example: Five of Diamonds would be 5d, King of Spades would be 13s");
        do
        {
            Card.Suit suit = default;
            Card.Value value = default;

            Console.WriteLine("Card selector. Choose a card to add, or type exit to finish:");
            Console.Write(": ");
            invalid = false;
            string choice = Console.ReadLine().ToLower();
            if (choice.Length < 2)
            {
                Console.WriteLine("Invalid input. Try again");
                continue;
            }
            string su = choice.Substring(choice.Length - 1, 1);
            string val = choice.Substring(0, choice.Length - 1);

            if (choice.ToLower()[0] == 'e')
            {
                if (cards.Count == 0)
                {
                    Console.WriteLine("No cards added, using default deck...");
                }
                config = new(p, new(cards), g);
                Console.WriteLine("Created configuration");
                return;
            }
            switch (su)
            {
                case "s":
                    suit = Card.Suit.Spade;
                    break;
                case "c":
                    suit = Card.Suit.Club;
                    break;
                case "d":
                    suit = Card.Suit.Diamond;
                    break;
                case "h":
                    suit = Card.Suit.Heart;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    invalid = true;
                    break;
            }
            if (!invalid)
            {
                switch (val)
                {
                    case "2":
                        value = Card.Value.Two;
                        break;
                    case "3":
                        value = Card.Value.Three;
                        break;
                    case "4":
                        value = Card.Value.Four;
                        break;
                    case "5":
                        value = Card.Value.Five;
                        break;
                    case "6":
                        value = Card.Value.Six;
                        break;
                    case "7":
                        value = Card.Value.Seven;
                        break;
                    case "8":
                        value = Card.Value.Eight;
                        break;
                    case "9":
                        value = Card.Value.Nine;
                        break;
                    case "10":
                        value = Card.Value.Ten;
                        break;
                    case "11":
                        value = Card.Value.Jack;
                        break;
                    case "12":
                        value = Card.Value.Queen;
                        break;
                    case "13":
                        value = Card.Value.King;
                        break;
                    case "14":
                        value = Card.Value.Ace;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        invalid = true;
                        break;
                }
                if (!invalid)
                {
                    do
                    {
                        Console.Write("How many of this card should be added?: ");
                        invalid = !int.TryParse(Console.ReadLine(), out int c);
                        if (invalid || c < 1)
                        {
                            Console.WriteLine("Invalid number. Try again");
                            invalid = true;
                        }
                        for(int i = 0; i < c; i++)
                        {
                            cards.Add(new(suit, value));
                        }
                    } while (invalid);
                }
            }


        } while (true);
    }

    public static void ConfigSave()
    {
        if (config is null)
        {
            Console.WriteLine("There is no configuration to save");
            return;
        }
        else
        {
            Console.Write("Enter file name to save as: ");
            string filename = Console.ReadLine();
            if (filename == "")
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
        if (filename == "")
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

    public static void ReportView()
    {
        if (report is null)
        {
            Console.WriteLine("There is no report to view");
            return;
        }
        report.Display();
    }

    public static void ReportSave()
    {
        if (report is null)
        {
            Console.WriteLine("There is no report to save");
            return;
        }
        else
        {
            Console.Write("Enter file name to save as: ");
            string filename = Console.ReadLine();
            if (filename == "")
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

    public static void ReportLoad()
    {
        Console.Write("Report filename: ");
        string filename = Console.ReadLine();
        if (filename == "")
        {
            Console.WriteLine($"Using default {defaultReport}");
            filename = defaultReport;
        }
        string f = System.IO.File.ReadAllLines(filename)[0];
        report = JsonSerializer.Deserialize<Report>(f);
        Console.WriteLine("Report loaded");
    }
}