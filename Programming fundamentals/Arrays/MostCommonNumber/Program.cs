using System;
using System.Linq;

namespace MostCommonNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // NOTE: This is not a recommended way of solving such problems. Dictionary should be used. However, by the time we have not learned about it.
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int mostCommonNumber = 0, mostOccurrences = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int currentOccurrences = 1;
                for (int j = 0; j < array.Length; j++)
                {
                    if (i != j && array[i] == array[j]) currentOccurrences++;
                }

                if (currentOccurrences > mostOccurrences)
                {
                    mostCommonNumber = array[i];
                    mostOccurrences = currentOccurrences;
                }
            }

            Console.WriteLine(mostCommonNumber);
        }
    }
}