using System;
using System.Collections.Generic;

namespace OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> occurrencesByWord = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i].ToLower();

                // 1. If not seen, set default
                // 2. Change
                if (!occurrencesByWord.ContainsKey(currentWord))
                    occurrencesByWord[currentWord] = 0;
                occurrencesByWord[currentWord]++;
            }

            List<string> result = new List<string>();
            foreach (var (key, value) in occurrencesByWord)
            {
                if (value % 2 != 0) result.Add(key);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}