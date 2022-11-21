using System;

namespace MinNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber < min) min = currentNumber;
            }

            Console.WriteLine(min);
        }
    }
}
