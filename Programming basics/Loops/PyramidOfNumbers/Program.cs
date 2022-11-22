using System;

namespace PyramidOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int numberToPrint = 1, numbersPerRow = 1;
            while (numberToPrint <= n)
            {
                for (int i = 0; i < numbersPerRow && numberToPrint <= n; i++)
                    Console.Write($"{numberToPrint++} ");

                Console.WriteLine();
            }
        }
    }
}
