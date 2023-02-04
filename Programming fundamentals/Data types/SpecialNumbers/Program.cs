using System;

namespace SpecialNumbers
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int digitSum = CalculateSumOfDigits(i);
                bool isSpecial = digitSum == 5 || digitSum == 7 || digitSum == 11;
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }

        private static int CalculateSumOfDigits(int number)
        {
            int digitSum = 0;
            while (number != 0)
            {
                digitSum += number % 10;
                number /= 10;
            }

            return digitSum;
        }
    }
}