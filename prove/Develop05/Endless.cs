using System.Text.Json;
using System.Text.Json.Serialization;

class Endless : Goal
{
    [JsonInclude]
    private int _completions;

    public Endless(string name, string description, int points, int completions) : base(name, description, points, false)
    {
        _completions = completions;
    }

    [JsonConstructor] 
    public Endless() : base()
    { 
    }

    public override void Update()
    {
        Console.Write("How many completions would you like to add?: ");
        if (int.TryParse(Console.ReadLine(), out int i))
        {
            _completions += i;
        }
        else
        {
            Console.WriteLine("Invalid input. Goal unchanged.");
        }
        Console.WriteLine("No more changes available for this type.");
    }


    public override string Save()
    {
        string saved = "3|";
        saved += JsonSerializer.Serialize(this);
        return saved;
    }

    public override void Display()
    {
        Console.WriteLine($"Goal: {_name}");
        Console.WriteLine(_description);
        Console.WriteLine("Eternal");
        Console.WriteLine($"Points: {GetPoints()}");
    }

    public override int GetPoints()
    {
        return _points * _completions;
    }
}