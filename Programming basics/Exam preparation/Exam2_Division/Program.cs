using System;

namespace Exam2_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int d1 = 0, d2 = 0, d3 = 0;
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber % 2 == 0) d1++;
                if (currentNumber % 3 == 0) d2++;
                if (currentNumber % 4 == 0) d3++;
            }

            Console.WriteLine($"{(double)d1 / n * 100:f2}%");
            Console.WriteLine($"{(double)d2 / n * 100:f2}%");
            Console.WriteLine($"{(double)d3 / n * 100:f2}%");
        }
    }
}
