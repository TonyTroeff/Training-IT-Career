using System;

namespace SunGlasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintBorderRow(n);
            for (int i = 0; i < n - 2; i++)
            {
                if (i + 1 == (n - 1) / 2) PrintMiddleRow(n, '|');
                else PrintMiddleRow(n, ' ');
            }
            PrintBorderRow(n);
        }

        static void PrintBorderRow(int n)
        {
            for (int i = 0; i < 2 * n; i++) Console.Write('*');
            for (int i = 0; i < n; i++) Console.Write(' ');
            for (int i = 0; i < 2 * n; i++) Console.Write('*');

            Console.WriteLine();
        }

        static void PrintMiddleRow(int n, char middleSymbol)
        {
            Console.Write('*');
            for (int i = 0; i < n * 2 - 2; i++) Console.Write('/');
            Console.Write('*');

            for (int i = 0; i < n; i++) Console.Write(middleSymbol);

            Console.Write('*');
            for (int i = 0; i < n * 2 - 2; i++) Console.Write('/');
            Console.Write('*');

            Console.WriteLine();
        }
    }
}
