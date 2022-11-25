using System;

namespace DrawFillRectangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintBorder(n);
            for (int i = 0; i < n - 2; i++) PrintMiddle(n);
            PrintBorder(n);
        }

        static void PrintBorder(int n)
        {
            for (int i = 0; i < 2 * n; i++) Console.Write('-');
            Console.WriteLine();
        }

        static void PrintMiddle(int n)
        {
            Console.Write('-');
            for (int i = 0; i < n - 1; i++) Console.Write("\\/");
            Console.Write('-');
        }
    }
}
