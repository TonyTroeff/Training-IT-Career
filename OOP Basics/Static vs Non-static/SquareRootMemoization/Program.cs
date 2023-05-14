using System;

namespace SquareRootMemoization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());
                double sqrt = SquareRootCache.GetSquareRoot(number);
                Console.WriteLine(sqrt);
            }
        }
    }
}
