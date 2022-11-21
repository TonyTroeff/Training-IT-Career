using System;

namespace SquareFrame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintRow('+', n);
            for (int i = 0; i < n - 2; i++) PrintRow('|', n);
            PrintRow('+', n);
        }

        static void PrintRow(char edgeSymbol, int n)
        {
            Console.Write(edgeSymbol);
            
            if (n <= 2) Console.Write(' ');
            else
            {
                for (int i = 0; i < n - 2; i++) Console.Write(' ');
            }

            Console.Write(edgeSymbol);
            Console.WriteLine();
        }
    }
}
