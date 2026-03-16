class Program
{
    private static List<Goal> goals = [];

    public static void Main(string[] args)
    {
        //main menu
        bool cont = true;
        string choice = "";
        Console.WriteLine("Welcome to The Eternal Quest!");
        do
        {
            Console.WriteLine($"Current Points: {GetAllPoints()}");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Display all goals\n2. Create goal\n3. Update goal\n4. Save goals\n5. Load goals\n6. Exit");
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
                Console.Clear();
                Console.WriteLine("Invalid choice. Try again.");
            }
        } while (cont);
    }


    public static void DisplayAll()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to display");
            return;
        }
        foreach (Goal g in goals)
        {
            g.Display();
            Console.WriteLine();
        }
    }

    public static int GetAllPoints()
    {
        if (goals.Count == 0)
        {
            return 0;
        }
        int count = 0;
        foreach(Goal g in goals)
        {
            count += g.GetPoints();
        }
        return count;
    }

    public static void Create()
    {
        Console.Clear();
        bool cont = true;
        do
        {
            Console.WriteLine("What type of goal would you like?");
            Console.WriteLine("1. One time goal\n2. Multiple attempt goal\n3. Endless goal");
            string choice = Console.ReadLine().ToLower();
            if (choice == "")
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
            else
            {
                string n = "";
                string d;
                int p;
                int comp;
                bool c;

                switch (choice[0])
                {
                    case '1' or 'o':

                        Console.Write("Enter the name of the goal: ");
                        n = Console.ReadLine();

                        Console.Write("Enter the description for the goal: ");
                        d = Console.ReadLine();

                        Console.Write("Enter how many points the goal is worth: ");

                        if (!int.TryParse(Console.ReadLine(), out p))
                        {
                            Console.WriteLine("Invalid number, retrying creation");
                            break;
                        }

                        Console.Write("Have you completed this goal yet (Y/n): ");
                        c = true;
                        if (Console.ReadLine().ToLower()[0] == 'n')
                        {
                            c = false;
                        }

                        goals.Add(new Single(n, d, p, c));
                        cont = false;
                        break;
                    case '2' or 'm':

                        Console.Write("Enter the name of the goal: ");
                        n = Console.ReadLine();

                        Console.Write("Enter the description for the goal: ");
                        d = Console.ReadLine();

                        Console.Write("Enter how many points a single completion of the goal is worth: ");

                        if (!int.TryParse(Console.ReadLine(), out p))
                        {
                            Console.WriteLine("Invalid number, retrying creation");
                            break;
                        }

                        Console.Write("Enter how many times have completed this goal: ");

                        if (!int.TryParse(Console.ReadLine(), out comp))
                        {
                            Console.WriteLine("Invalid number, retrying creation");
                            break;
                        }

                        Console.Write("Enter how many times you want to complete this goal: ");

                        if (!int.TryParse(Console.ReadLine(), out int g))
                        {
                            Console.WriteLine("Invalid number, retrying creation");
                            break;
                        }

                        Console.Write("Enter how many points will be awarded for meeting the target number of completions: ");

                        if (!int.TryParse(Console.ReadLine(), out int t))
                        {
                            Console.WriteLine("Invalid number, retrying creation");
                            break;
                        }

                        goals.Add(new Multiple(n, d, p, t, comp, g));
                        cont = false;
                        break;
                    case '3' or 'e':

                        Console.Write("Enter the name of the goal: ");
                        n = Console.ReadLine();

                        Console.Write("Enter the description for the goal: ");
                        d = Console.ReadLine();

                        Console.Write("Enter how many points a single completion of the goal is worth: ");

                        if (!int.TryParse(Console.ReadLine(), out p))
                        {
                            Console.WriteLine("Invalid number, retrying creation");
                            break;
                        }

                        Console.Write("Enter how many times have completed this goal: ");

                        if (!int.TryParse(Console.ReadLine(), out comp))
                        {
                            Console.WriteLine("Invalid number, retrying creation");
                            break;
                        }

                        goals.Add(new Endless(n, d, p, comp));
                        cont = false;
                        break;
                    case '0':
                        Console.WriteLine("Back to main menu");
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            }

        } while (cont);
    }

    public static void Update()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to update");
            return;
        }
        Console.Clear();
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {goals[i].GetName()}");
        }
        bool cont = true;
        do
        {
            Console.Write("Choose a goal to update: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                choice--;
                if (choice == -1)
                {
                    Console.WriteLine("Returning to main menu");
                    cont = false;
                }
                else if (choice < -1 || choice >= goals.Count())
                {
                    Console.WriteLine("Invalid choice. Try again");
                }
                else
                {
                    goals[choice].Update();
                    Console.WriteLine("Returning to main menu");
                    cont = false;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again");
            }
        } while (cont);


    }

    public static void Save()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("Action not available. There are no goals.");
        }
        else
        {
            Console.Write("Enter file name to save as: ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new(filename))
            {
                foreach (Goal g in goals)
                {
                    outputFile.WriteLine(g.Save());
                }
            }
        }

    }

    public static void Load()
    {
        Console.Write("Enter the name of the file: ");
        string filename = Console.ReadLine();
        List<string> f = [.. System.IO.File.ReadAllLines(filename)];
        List<Goal> newGoals = [];

        foreach (string l in f)
        {
            Goal g = Goal.Parse(l);
            if (g != null)
            {
                newGoals.Add(g);
            }
        }
        goals = newGoals;
    }
}