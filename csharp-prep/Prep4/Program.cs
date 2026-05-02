using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        string adding = "yes";
        do
        {
            Console.Write("Enter number: ");
            string newNum = Console.ReadLine();
            int num = int.Parse(newNum);
            if (num != 0)
            {
                numbers.Add(num);
            }
            else
            {
                adding = "no";
            }
        } while (adding == "yes");
        int sum = 0;
        int max = 0;
        int quantity = numbers.Count;
        foreach (int i in numbers)
        {
            sum += i;
            if (i > max)
            {
                max = i;
            }
        }
        Console.WriteLine($"The sum is: {sum}");
        float ave = ((float)sum) / quantity;
        Console.WriteLine($"The average is: {ave}");
        Console.WriteLine($"The largest number is: {max}");
    }
}