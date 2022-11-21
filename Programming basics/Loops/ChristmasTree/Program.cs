using System;

namespace ChristmasTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++) PrintRow(i, n);
        }

        static void PrintRow(int stars, int n)
        {
            for (int i = 0; i < n - stars; i++) Console.Write(' ');
            for (int i = 0; i < stars; i++) Console.Write('*');

            Console.Write(" | ");

            for (int i = 0; i < stars; i++) Console.Write('*');
            for (int i = 0; i < n - stars; i++) Console.Write(' ');

            Console.WriteLine();
        }
    }
}
