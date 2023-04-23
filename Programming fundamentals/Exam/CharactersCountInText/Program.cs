using System;
using System.Collections.Generic;

namespace CharactersCountInText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> occurrences = new Dictionary<char, int>();
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    if (!occurrences.ContainsKey(text[i])) occurrences[text[i]] = 0;
                    occurrences[text[i]]++;
                }
            }

            foreach(var (symbol, count) in occurrences) Console.WriteLine($"{symbol} -> {count}");
        }
    }
}