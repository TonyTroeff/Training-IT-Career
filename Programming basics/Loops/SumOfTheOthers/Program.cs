using System;

namespace SumOfTheOthers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int max = int.MinValue, sum = 0;
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber;
                if (currentNumber > max) max = currentNumber;
            }

            int sumOfOthers = sum - max;

            if (max == sumOfOthers) Console.WriteLine($"Yes, Sum = {sumOfOthers}");
            else Console.WriteLine($"No, diff = {Math.Abs(sumOfOthers - max)}");
        }
    }
}
