using System;

namespace CountSubstringOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            int count = 0;
            int indexOfOccurrence = first.IndexOf(second);
            while (indexOfOccurrence >= 0)
            {
                count++;
                indexOfOccurrence = first.IndexOf(second, indexOfOccurrence + 1);
            }

            Console.WriteLine(count);
        }
    }
}