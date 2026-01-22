public class Resume
{
    public string _name;
    public List<Job> _jobs = new();


    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job j in _jobs){
            j.Display();
        }
    }
}