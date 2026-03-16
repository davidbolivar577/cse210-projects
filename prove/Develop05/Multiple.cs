using System.Text.Json;
using System.Text.Json.Serialization;

class Multiple : Goal
{
    [JsonInclude]
    private int _bonusPoints;
    [JsonInclude]
    private int _completions;
    [JsonInclude]
    private int _goalCompletions;

    public Multiple(string name, string description, int points, int bonus, int completions, int goalCompletions) : base(name, description, points, false)
    {
        _bonusPoints = bonus;
        _completions = completions;
        _goalCompletions = goalCompletions;

        if(_completions >= _goalCompletions)
        {
            _completed = true;
        }
    }

    [JsonConstructor] 
    public Multiple() : base()
    { 
    }

    public override void Update()
    {
        Console.Write("How many completions would you like to add?: ");
        if (int.TryParse(Console.ReadLine(), out int i))
        {
            _completions += i;
            if(_completions >= _goalCompletions)
            {
                _completed = true;
            }
            else
            {
                _completed = false;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Goal unchanged.");
        }
        Console.WriteLine("No more changes available for this type.");
    }


    public override string Save()
    {
        string saved = "2|";
        saved += JsonSerializer.Serialize(this);
        return saved;
    }

    public override void Display()
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
        Console.WriteLine($"Points: {GetPoints()}");
    }

    public override int GetPoints()
    {
        int total = _points * _completions;
        if (IsComplete())
        {
            total += _bonusPoints;
        }
        return total;
    }
}