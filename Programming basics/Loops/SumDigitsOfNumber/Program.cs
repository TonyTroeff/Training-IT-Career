using System;

namespace SumDigitsOfNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int digitsSum = 0;
            while (n > 0)
            {
                digitsSum += n % 10;
                n /= 10;
            }

            Console.WriteLine(digitsSum);
        }
    }
}
