using System;

namespace Exam2_Butterfly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintBody(n, true);
            PrintMiddle(n);
            PrintBody(n, false);
        }
        static void PrintBody(int n, bool isUpper)
        {
            for (int i = 0; i < n - 2; i++)
            {
                if (i % 2 == 0)
                    PrintRow(n, '*', isUpper);
                else
                    PrintRow(n, '-', isUpper);
            }
        }

        static void PrintMiddle(int n)
        {
            for (int i = 0; i < n - 1; i++)
                Console.Write(' ');
            Console.WriteLine('@');
        }

        static void PrintRow(int n, char c, bool isUpper)
        {
            for (int i = 0; i < n - 2; i++)
                Console.Write(c);

            if (isUpper) Console.Write("\\/");
            else Console.Write("/\\");

            for (int i = 0; i < n - 2; i++)
                Console.Write(c);

            Console.WriteLine();
        }
    }
}
