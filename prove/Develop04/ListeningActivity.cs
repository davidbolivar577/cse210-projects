public class ListeningActivity : Activity
{
    List<string> questionList = ["Who are people that you appreciate? ", "What are personal strengths of yours? ", "Who are people that you have helped this week? ", "When have you felt the Holy Ghost this month? ", "Who are some of your personal heroes? "];
    List<int> selectedQuestions = [];
    Random r = new();
    public ListeningActivity()
    {
        _name = "Listening Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void Run()
    {
        Start();
        int count = 0;
        Console.WriteLine("Think about the following\n");
        //select prompt
        Console.WriteLine(questionList[r.Next(questionList.Count)]);
        Wait(_timing * 2);
        DateTime end = DateTime.Now.AddSeconds(_duration);
        do
        {
            //take response
            Console.Write($"{count + 1}: ");
            Console.ReadLine();
            count++;
        } while (DateTime.Now < end);
        Console.WriteLine($"You answered {count} times");
        End();
    }
}