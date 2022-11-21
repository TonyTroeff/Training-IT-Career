using System;

namespace EvenOddSums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int evenSum = 0, oddSum = 0;
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (i % 2 == 0) evenSum += currentNumber;
                else oddSum += currentNumber;
            }

            if (evenSum == oddSum) Console.WriteLine($"Yes, sum = {evenSum}");
            else Console.WriteLine($"No, diff = {Math.Abs(evenSum - oddSum)}");
        }
    }
}
