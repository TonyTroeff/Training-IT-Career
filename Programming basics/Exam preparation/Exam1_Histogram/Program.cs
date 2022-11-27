using System;

namespace Exam1_Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0;
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < 200) d1++;
                else if (currentNumber < 400) d2++;
                else if (currentNumber < 600) d3++;
                else if (currentNumber < 800) d4++;
                else d5++;
            }

            Console.WriteLine($"{(double)d1 / n * 100:f2}%");
            Console.WriteLine($"{(double)d2 / n * 100:f2}%");
            Console.WriteLine($"{(double)d3 / n * 100:f2}%");
            Console.WriteLine($"{(double)d4 / n * 100:f2}%");
            Console.WriteLine($"{(double)d5 / n * 100:f2}%");
        }
    }
}
