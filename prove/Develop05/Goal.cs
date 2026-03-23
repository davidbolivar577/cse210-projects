using System.Text.Json;
using System.Text.Json.Serialization;

abstract class Goal
{
    [JsonInclude]
    protected string _name;
    [JsonInclude]
    protected string _description;
    [JsonInclude]
    protected int _points;
    [JsonInclude]
    protected bool _completed;

    public Goal(string name, string description, int points, bool completed)
    {
        _name = name;
        _description = description;
        _points = points;
        _completed = completed;
    }

    public Goal()
    {
        
    }

    public static Goal Parse(string p)
{
    string parser = p[..2];
    string parsed = p[2..];
    Goal goal;
    try
    {
        switch (parser)
        {
            case "1|":
                goal = JsonSerializer.Deserialize<Single>(parsed);
                break;
            case "2|":
                goal = JsonSerializer.Deserialize<Multiple>(parsed);
                break;
            case "3|":
                goal = JsonSerializer.Deserialize<Endless>(parsed);
                break;
            default:
                Console.Error.WriteLine("Invalid line found. Please save to remove");
                goal = null;
                break;
        }
    }
    catch (Exception)
    {
        Console.Error.WriteLine("Loading Error. Please save to remove");
        goal = null;
    }

    return goal;
}

public string GetName()
{
    return _name;
}

public virtual void Display()
{
    Console.WriteLine($"Goal: {_name}");
    Console.WriteLine(_description);
    if (IsComplete())
    {
        Console.WriteLine("Completed");
    }
    else
    {
        Console.WriteLine("Incomplete");
    }
    Console.WriteLine($"Points: {GetPoints()} out of {_points}");
}

public virtual int GetPoints()
{
    if (IsComplete())
    {
        return _points;
    }
    return 0;
}

public bool IsComplete()
{
    return _completed;
}

public abstract void Update();
public abstract string Save();
}