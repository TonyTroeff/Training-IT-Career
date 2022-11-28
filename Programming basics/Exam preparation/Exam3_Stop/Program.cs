using System;

namespace Exam3_Stop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // There are some issues with the tests for this task so don't worry if you are not able to get 100/100 points.
            int n = int.Parse(Console.ReadLine());

            PrintTop(n);
            for (int i = n; i >= 1; i--) PrintStandardRow(n, i, '/', '\\');
            PrintMiddleRow(n);

            int start = 1;
            if (n >= 100) start = 0;

            for (int i = start; i <= n - 1; i++) PrintStandardRow(n, i, '\\', '/');
        }

        static void PrintTop(int n)
        {
            Console.Write(new string('.', n + 1));
            Console.Write(new string('_', 2 * n + 1));
            Console.Write(new string('.', n + 1));

            Console.WriteLine();
        }

        static void PrintMiddleRow(int n)
        {
            Console.Write("//");

            int underscoresCount = 2 * n - 3;
            Console.Write(new string('_', underscoresCount));
            Console.Write("STOP!");
            Console.Write(new string('_', underscoresCount));

            Console.Write("\\\\");
            Console.WriteLine();
        }

        static void PrintStandardRow(int n, int t, char left, char right)
        {
            Console.Write(new string('.', t));
            Console.Write($"{left}{left}");

            Console.Write(new string('_', 4 * n - 2 * t - 1));

            Console.Write($"{right}{right}");
            Console.Write(new string('.', t));
            Console.WriteLine();
        }
    }
}
