using System;

namespace Exam5_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int firstDigit = (number / 100) % 10, secondDigit = (number / 10) % 10, thirdDigit = number % 10;
            int rows = firstDigit + secondDigit, columns = firstDigit + thirdDigit;
            int total = rows * columns, index = 0;

            while (index < total)
            {
                if (number % 5 == 0) number -= firstDigit;
                else if (number % 3 == 0) number -= secondDigit;
                else number += thirdDigit;

                Console.Write($"{number} ");

                if ((index + 1) % columns == 0) Console.WriteLine();
                index++;
            }
        }
    }
}
