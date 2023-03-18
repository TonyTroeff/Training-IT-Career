using System;
using System.Linq;

namespace SquareNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var result = numbers.Where(x => IsSquare(x)).OrderDescending();
            Console.WriteLine(string.Join(" ", result));

            /*int[] squareNumbers = new int[numbers.Length];
            int squareNumbersIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsSquare(numbers[i]))
                {
                    squareNumbers[squareNumbersIndex] = numbers[i];
                    squareNumbersIndex++;
                }
            }

            int[] trimmedResult = new int[squareNumbersIndex];
            Array.Copy(squareNumbers, trimmedResult, squareNumbersIndex);

            Array.Sort(trimmedResult);
            Array.Reverse(trimmedResult);
            Console.WriteLine(string.Join(' ', trimmedResult));*/
        }

        static bool IsSquare(int num)
        {
            double sqrt = Math.Sqrt(num);
            return sqrt == (int)sqrt;
        }
    }
}