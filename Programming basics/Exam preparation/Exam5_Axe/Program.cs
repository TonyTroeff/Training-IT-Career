using System;

namespace Exam5_Axe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int half = n / 2;

            for (int i = 0; i < n; i++) PrintStandardRow(n, 3 * n, '-', i, '-');
            for (int i = 0; i < half; i++) PrintStandardRow(n, 3 * n, '*', n - 1, '-');
            for (int i = 0; i < half - 1; i++) PrintStandardRow(n, 3 * n - i, '-', n - 1 + i * 2, '-');
            PrintStandardRow(n, 3 * n - half + 1, '-', n + half * 2 - 3, '*');
        }

        static void PrintStandardRow(int n, int startSegmentLength, char startSegmentChar, int middleSegmentLength, char middleSegmentChar)
        {
            Console.Write(new string(startSegmentChar, startSegmentLength));
            Console.Write('*');
            Console.Write(new string(middleSegmentChar, middleSegmentLength));
            Console.Write('*');
            Console.Write(new string('-', 5 * n - startSegmentLength - middleSegmentLength - 2));

            Console.WriteLine();
        }
    }
}
