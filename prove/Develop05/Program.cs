using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> _goals = new List<Goal>();
    static int _score = 0;

    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            Console.WriteLine($"You have {_score} points");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a number from the menu.");
                continue;
            }

            if (choice == 1)
            {
                CreateGoal();
            }
            else if (choice == 2)
            {
                ListGoals();
            }
            else if (choice == 3)
            {
                SaveGoals();
            }
            else if (choice == 4)
            {
                LoadGoals();
            }
            else if (choice == 5)
            {
                RecordEvent();
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Goal type: ");
        if (!int.TryParse(Console.ReadLine(), out int type))
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points value.");
            return;
        }

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            Console.Write("Target amount: ");
            if (!int.TryParse(Console.ReadLine(), out int target))
            {
                Console.WriteLine("Invalid target amount.");
                return;
            }

            Console.Write("Bonus points: ");
            if (!int.TryParse(Console.ReadLine(), out int bonus))
            {
                Console.WriteLine("Invalid bonus amount.");
                return;
            }
            
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    static void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    static void RecordEvent()
    {
        ListGoals();

        Console.Write("Which goal did you complete? ");

        if (int.TryParse(Console.ReadLine(), out int index))
        {
            index--;

            if (index >= 0 && index < _goals.Count)
            {
                int points = _goals[index].RecordEvent();
                _score += points;

                Console.WriteLine($"You earned {points} points!");
            }
            else
            {
                Console.WriteLine("That goal does not exist.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a number.");
        }
    }

    static void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] data = parts[1].Split(',');

            if (type == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(
                    data[0],
                    data[1],
                    int.Parse(data[2])
                );

                if (bool.Parse(data[3]))
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(
                    data[0],
                    data[1],
                    int.Parse(data[2])
                );

                _goals.Add(goal);
            }
            else if (type == "ChecklistGoal")
            {
                ChecklistGoal goal = new ChecklistGoal(
                    data[0],
                    data[1],
                    int.Parse(data[2]),
                    int.Parse(data[4]),
                    int.Parse(data[5])
                );

                goal.SetAmountCompleted(int.Parse(data[3]));

                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}