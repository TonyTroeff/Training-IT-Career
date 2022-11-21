using System;

namespace DiamondOfStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
                PrintRow(i, n - i);
            for (int i = n - 1; i >= 1; i--)
                PrintRow(i, n - i);
        }

        static void PrintRow(int countOfStars, int offset)
        {
            for (int i = 0; i < offset; i++) Console.Write(' ');
            for (int i = 0; i < countOfStars; i++) Console.Write("* ");
            Console.WriteLine();
        }
    }
}
