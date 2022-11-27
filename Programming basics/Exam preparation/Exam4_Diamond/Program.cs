using System;

namespace Exam4_Diamond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) Console.Write('.');
            for (int i = 0; i < 3 * n; i++) Console.Write('*');
            for (int i = 0; i < n; i++) Console.Write('.');
            Console.WriteLine();

            for (int i = n - 1; i >= 1; i--)
                PrintStandardRow(n, i);

            for (int i = 0; i < 5 * n; i++) Console.Write('*');
            Console.WriteLine();

            for (int i = 1; i <= n * 2; i++)
                PrintStandardRow(n, i);

            for (int i = 0; i < 2 * n + 1; i++) Console.Write('.');
            for (int i = 0; i < n - 2; i++) Console.Write('*');
            for (int i = 0; i < 2 * n + 1; i++) Console.Write('.');
            Console.WriteLine();
        }

        static void PrintStandardRow(int n, int offset)
        {
            for (int j = 0; j < offset; j++) Console.Write('.');
            Console.Write('*');

            int middleFill = 5 * n - offset * 2 - 2;
            for (int j = 0; j < middleFill; j++) Console.Write('.');

            Console.Write('*');
            for (int j = 0; j < offset; j++) Console.Write('.');

            Console.WriteLine();
        }
    }
}
