using System;

namespace NumberToWords100
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int tens = number / 10;
            int ones = number % 10;

            if (tens == 0)
            {
                if (ones == 0) Console.WriteLine("zero");
                else PrintDigit(ones);
            }
            else if (tens == 1)
            {
                if (ones == 0) Console.WriteLine("ten");
                else if (ones == 1) Console.WriteLine("eleven");
                else if (ones == 2) Console.WriteLine("twelve");
                else if (ones == 3) Console.WriteLine("thirteen");
                else if (ones == 4) Console.WriteLine("fourteen");
                else if (ones == 5) Console.WriteLine("fifteen");
                else if (ones == 6) Console.WriteLine("sixteen");
                else if (ones == 7) Console.WriteLine("seventeen");
                else if (ones == 8) Console.WriteLine("eightteen");
                else if (ones == 9) Console.WriteLine("nineteen");
            }
            else if (tens < 10)
            {
                if (tens == 2) Console.Write("twenty");
                else if (tens == 3) Console.Write("thirty");
                else if (tens == 4) Console.Write("forty");
                else if (tens == 5) Console.Write("fifty");
                else if (tens == 6) Console.Write("sixty");
                else if (tens == 7) Console.Write("seventy");
                else if (tens == 8) Console.Write("eighty");
                else if (tens == 9) Console.Write("ninety");

                if (ones != 0)
                {
                    Console.Write(" ");
                    PrintDigit(ones);
                }
            }
            else if (tens == 10)
            {
                if (ones == 0) Console.WriteLine("one hundred");
            }
        }

        static void PrintDigit(int digit)
        {
            // This is used to print a single digit
            // Such a method can be used when printing two digit numbers, e.g. twenty [one]
            if (digit == 1) Console.WriteLine("one");
            else if (digit == 2) Console.WriteLine("two");
            else if (digit == 3) Console.WriteLine("three");
            else if (digit == 4) Console.WriteLine("four");
            else if (digit == 5) Console.WriteLine("five");
            else if (digit == 6) Console.WriteLine("six");
            else if (digit == 7) Console.WriteLine("seven");
            else if (digit == 8) Console.WriteLine("eight");
            else if (digit == 9) Console.WriteLine("nine");
        }
    }
}
