using System;

namespace EvenOddSumMultiplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int result = Solve(number);
            Console.WriteLine(result);
        }

        static int Solve(int number)
        {
            if (number < 0) number *= -1;

            int oddSum = 0, evenSum = 0;
            while (number > 0)
            {
                int lastDigit = number % 10;
                if (lastDigit % 2 == 0) evenSum += lastDigit;
                else oddSum += lastDigit;

                number /= 10;
            }

            return oddSum * evenSum;
        }
    }
}
