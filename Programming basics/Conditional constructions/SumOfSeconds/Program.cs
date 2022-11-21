using System;

namespace SumOfSeconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int sum = a + b + c;
            int minutes = sum / 60;
            int seconds = sum % 60;

            if (seconds < 10) Console.WriteLine($"{minutes}:0{seconds}");
            else Console.WriteLine($"{minutes}:{seconds}");
        }
    }
}
