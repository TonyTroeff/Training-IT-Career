using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> evenNumbers = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0) evenNumbers.Add(numbers[i]);
            }

            Console.WriteLine(string.Join(" ", evenNumbers));
        }
    }
}