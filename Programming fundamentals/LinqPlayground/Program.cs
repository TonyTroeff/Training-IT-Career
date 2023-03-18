using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            /*List<int> evenNumbers = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0) evenNumbers.Add(numbers[i]);
            }*/
            int[] evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();
            Console.WriteLine($"Even numbers are: {string.Join(", ", evenNumbers)}");

            int[] threeDigitNumbers = numbers.Where(x => x >= 100 && x <= 999).ToArray();
            Console.WriteLine($"Three digit numbers: {string.Join(", ", threeDigitNumbers)}");

            int[] numbersOrderedAsc = numbers.OrderBy(x => x).ToArray();
            int[] numbersOrderedDesc = numbers.OrderByDescending(x => x).ToArray();
            Console.WriteLine($"Ascending order: {string.Join(", ", numbersOrderedAsc)}");
            Console.WriteLine($"Descending order: {string.Join(", ", numbersOrderedDesc)}");

            int[] topThreeNumbers = numbers.OrderByDescending(x => x).Take(3).ToArray();
            Console.WriteLine($"Top three numbers: {string.Join(", ", topThreeNumbers)}");

            Dictionary<int, int> occurrencesByNumber = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!occurrencesByNumber.ContainsKey(numbers[i]))
                    occurrencesByNumber[numbers[i]] = 0;
                occurrencesByNumber[numbers[i]]++;
            }

            foreach (var (num, occurrencesCount) in occurrencesByNumber.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                Console.WriteLine($"{num} -> {occurrencesCount}");
        }
    }
}