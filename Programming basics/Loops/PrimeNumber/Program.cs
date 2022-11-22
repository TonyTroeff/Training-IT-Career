using System;

namespace PrimeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double sqrt = Math.Sqrt(number);

            bool isPrime = number >= 2;
            for (int i = 2; i <= sqrt && isPrime; i++)
            {
                if (number% i == 0) isPrime = false;
            }

            if (isPrime) Console.WriteLine("Prime");
            else Console.WriteLine("Not prime");
        }
    }
}
