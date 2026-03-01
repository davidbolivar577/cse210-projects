public class ReflectionActivity : Activity
{
    private List<string> promptList = ["Think of a time when you stood up for someone else. ", "Think of a time when you did something really difficult. ", "Think of a time when you helped someone in need. ", "Think of a time when you did something truly selfless. "];
    private List<string> questionList = ["Why was this experience meaningful to you? ", "Have you ever done anything like this before? ", "How did you get started? ", "How did you feel when it was complete? ", "What made this time different than other times when you were not as successful? ", "What is your favorite thing about this experience? ", "What could you learn from this experience that applies to other situations? ", "What did you learn about yourself through this experience? ", "How can you keep this experience in mind in the future? "];
    private List<int> selectedQuestions = [];
    private Random r = new();
    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void Run()
    {
        Start();
        //select prompt
        Console.WriteLine("Think about the following:\n");
        Console.WriteLine(promptList[r.Next(promptList.Count)]);
        Console.WriteLine();
        Wait(_timing * 2);
        DateTime end = DateTime.Now.AddSeconds(_duration);
        do
        {
            //ask question
            Question();
            Wait(_timing);
            Console.WriteLine();
        } while (DateTime.Now < end);
        End();
    }

    private void Question()
    {
        int next;
        do
        {
            if (selectedQuestions.Count >= questionList.Count)
            {
                selectedQuestions = [];
            }
            next = r.Next(questionList.Count);
        } while (selectedQuestions.Contains(next));
        selectedQuestions.Add(next);
        Console.Write(questionList[next]);
    }
}