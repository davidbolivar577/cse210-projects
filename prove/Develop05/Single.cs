using System.Text.Json;
using System.Text.Json.Serialization;

class Single : Goal
{
    public Single(string name, string description, int points, bool completed) : base(name, description, points, completed)
    {
        
    }
    
    [JsonConstructor] 
    public Single() : base()
    { 
    }
    
    public override void Update()
    {
        Console.Write("Would you like to set this goal as complete? (Y/n): ");
        string choice = Console.ReadLine().ToLower();
        if (choice[0] == 'n')
        {
            Console.WriteLine("Goal unchanged.");
        }
        else if (choice[0] == 'y')
        {
            Console.WriteLine("Goal marked as complete");
            _completed = true;
        }
        else
        {
            Console.WriteLine("Invalid choice, skipping");
        }
        Console.WriteLine("No more changes available for this type.");
    }


    public override string Save()
    {
        string saved = "1|";
        saved += JsonSerializer.Serialize(this);
        Console.WriteLine(JsonSerializer.Serialize(this));
        return saved;
    }
}