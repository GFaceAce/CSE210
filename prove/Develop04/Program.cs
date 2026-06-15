using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    public void SetDuration(int duration)
    {
        _duration = duration;
    }
    public int GetDuration()
    {
        return _duration;
    }
    public void Spinner(int seconds)
    {
        char[] symbols = {'/', '|','\\','-'};
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(symbols[i % symbols.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }
    public void Ready()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        char[] symbols = {'/', '|','\\','-'};
        for (int i = 0; i < 10; i++)
        {
            Console.Write(symbols[i % symbols.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
    public void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity()
    : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
    )
    {    
    }
    public void Run()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Breathing Activity.");
        Console.WriteLine();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        SetDuration(int.Parse(Console.ReadLine()));
        Ready();
        DateTime end = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < end)
        {
            Console.WriteLine("Breathe in...");
            Countdown(3);
            Console.WriteLine();
            Console.WriteLine("Now breathe out...");
            Countdown(3);
            Console.WriteLine();
        }
        Console.WriteLine("Well done!");
        Spinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {GetDuration()} seconds of the Breathing Activity.");
        Spinner(3);
    }
}

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something selfless."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?",
        "What could you learn from this experience?",
        "How can you keep this in mind in the future?"
    };
    private Random _random = new Random();
    public ReflectingActivity()
    : base(
        "Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in aspects of your life."
    )
    {
    }
    public void Run()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Reflecting Activity.");
        Console.WriteLine();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in aspects of your life.");
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        SetDuration(int.Parse(Console.ReadLine()));
        Ready();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine(" --- " + GetPrompt() + " --- ");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Now ponder on the following questions:");
        Console.Write("You may begin in: ");
        Countdown(5);
        DateTime end = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < end)
        {
            Console.WriteLine();
            Console.Write("> " + GetQuestion());
            Spinner(4);
        }
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Spinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {GetDuration()} seconds of the Reflecting Activity.");
        Spinner(3);
    }
    private string GetPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
    private string GetQuestion()
    {
        return _questions[_random.Next(_questions.Count)];
    }
}

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who are people you have helped recently?",
        "When have you felt inspired this month?",
        "Who are your personal heroes?"
    };
    private Random _random = new Random();
    public ListingActivity()
    : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by listing as many things as you can in a certain area."
    )
    {
    }
    public void Run()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Listing Activity.");
        Console.WriteLine();
        Console.WriteLine("This activity will help you reflect on the good things in your life by listing as many things as you can in a certain area.");
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        SetDuration(int.Parse(Console.ReadLine()));
        Ready();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine(" --- " + GetPrompt() + " --- ");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        Countdown(5);
        Console.WriteLine();
        int count = 0;
        DateTime end = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < end)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                count++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items!");
        Console.WriteLine("Well done!");
        Spinner(3);
    }
    private string GetPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}

class Program
{
    public void Run()
    {
        int choice = 0;
        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            int.TryParse(Console.ReadLine(), out choice);
            if (choice == 1)
            {
                new BreathingActivity().Run();
            }
            else if (choice == 2)
            {
                new ReflectingActivity().Run();
            }
            else if (choice == 3)
            {
                new ListingActivity().Run();
            }
        }
    }
    static void Main(string[] args)
    {
        new Program().Run();
    }
}