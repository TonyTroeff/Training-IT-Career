using System;
using System.Linq;

namespace LongestSubArrayOfCommonElements
{
    internal class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int max = 0;
            int index = 0;
            while (index < numbers.Length)
            {
                int start = index;
                while (index + 1 < numbers.Length && numbers[index + 1] > numbers[index]) index++;

                int currentOccurrences = index - start + 1;
                if (currentOccurrences > max)
                    max = currentOccurrences;

                index++;
            }

            Console.WriteLine($"The longest sub-array has length {max}.");
        }
    }
}
