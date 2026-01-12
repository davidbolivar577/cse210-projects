using System;

class Program
{
    static void Main(string[] args)
    {
        bool answer = true;
        int count = 0;

        Random randomGenerator = new Random();
        int magic = randomGenerator.Next(1, 101);

        do
        {
            count++;

            Console.Write("What is your guess?: ");
            int guess = int.Parse(Console.ReadLine());
            if (magic > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magic < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You got it!");
                Console.WriteLine($"You made {count} guesses");
                Console.Write("Do you want to play again? (y/n): ");
                string cont = Console.ReadLine().ToLower();
                if (cont.Substring(0, 1) == "y")
                {
                    magic = randomGenerator.Next(1, 101);
                }
                else
                {
                    answer = false;
                }

            }
        }
        while (answer);
    }
}