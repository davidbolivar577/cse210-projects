public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Run()
    {
        Start();
        DateTime end = DateTime.Now.AddSeconds(_duration);
        Wait(_timing);
        do
        {
            //in
            Console.Write("Breath in ");
            Wait(_timing);
            //Out
            Console.Write("Breath out ");
            Wait(_timing);
            Console.WriteLine();
        } while (DateTime.Now < end);
        End();
    }
}