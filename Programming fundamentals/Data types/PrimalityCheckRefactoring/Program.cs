using System;

namespace PrimalityCheckRefactoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            for (int i = 0; i <= end; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine($"{i} -> {isPrime}");
            }
        }
    }
}