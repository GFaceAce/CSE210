using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magic = randomGenerator.Next(1,100);
        string guessed = "no";
        do
        {
            Console.Write("What is your guess? ");
            string guess = Console.ReadLine();
            int num = int.Parse(guess);
            if (magic < num)
            {
                Console.WriteLine("Lower");
            }
            else if (magic > num)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                guessed = "yes";
            }
        } while (guessed == "no");
        
    }
}