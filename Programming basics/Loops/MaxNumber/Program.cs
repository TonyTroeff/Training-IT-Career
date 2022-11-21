using System;

namespace MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber > max) max = currentNumber;
            }

            Console.WriteLine(max);
        }
    }
}
