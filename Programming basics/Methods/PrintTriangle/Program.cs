using System;

namespace PrintTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) PrintRow(i);
            for (int i = n - 1; i >= 1; i--) PrintRow(i);
        }

        static void PrintRow(int numbersCount)
        {
            for (int i = 1; i <= numbersCount; i++) Console.Write($"{i} ");
            Console.WriteLine();
        }
    }
}
