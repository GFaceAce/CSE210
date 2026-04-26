using System;
using System.Globalization;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade? ");
        string grade = Console.ReadLine();
        int number = int.Parse(grade);
        string letter = "";

        if (number < 60)
        {
            letter = "F";
        }
        else if (number < 70)
        {
            letter = "D";
        }
        else if (number < 80)
        {
            letter = "C";
        }
        else if (number < 90)
        {
            letter = "B";
        }
        else
        {
            letter = "A";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (number >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("You failed.");
        }
    }
}