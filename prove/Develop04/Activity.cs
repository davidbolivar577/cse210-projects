public class Activity
{
    protected string _name;
    protected string _description;
    //hardcoded pause timing
    protected static int _timing = 5;
    protected int _duration = 0;

    protected static string _animation = "<>";
    protected const string _baseAnimation = "<>";

    public Activity()
    {
        _name = "default";
        _description = "default";
    }

    public void Start()
    {
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine($"{_description}\n");

        Console.Write("How long, in seconds, would you like the activity to last?: ");
        string choice = Console.ReadLine();
        if(choice.ToLower()[0] == 't')
        {
            Console.Write("Hidden Menu triggered:\nHow long, in seconds, would you like each small pause to last?: ");
            choice = Console.ReadLine();
            if(int.TryParse(choice, out int newTiming) && newTiming >= 1)
            {
                _timing = newTiming;
            }
            if(newTiming > 60)
            {
                _timing = 60;
            }
            Console.Write("How long, in seconds, would you like the activity to last?: ");
            choice = Console.ReadLine();
        }
        _duration = int.Parse(choice);
        Console.Clear();
        Console.WriteLine($"Begining {_name}");
    }

    public void End()
    {
        Console.WriteLine($"Good work completing {_name}");

    }

    public virtual void Run()
    {
        Console.WriteLine("No valid option chosen. Now pausing for 30 seconds.");
        Wait(30);
    }


    public static void Wait(int timer)
    {
        DateTime end = DateTime.Now.AddSeconds(timer);
        int count = 0;
        do
        {
            _animation = string.Concat(Enumerable.Repeat(_baseAnimation, timer - count));
            Console.Write($"{timer - count} {_animation}");
            Thread.Sleep(750);
            Backspace(_animation.Length + 1);
            Thread.Sleep(250);
            Backspace((timer - count).ToString().Length);
            count++;
        } while (DateTime.Now < end);
        
        Console.WriteLine();
    }

    public static void Backspace(int length)
    {
        Console.Write(new string('\b', length));
        Console.Write(new string(' ', length));
        Console.Write(new string('\b', length));
    }
}