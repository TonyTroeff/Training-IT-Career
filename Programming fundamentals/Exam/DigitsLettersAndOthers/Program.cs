using System;
using System.Collections.Generic;

namespace DigitsLettersAndOthers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<char> digits = new List<char>(), letters = new List<char>(), others = new List<char>();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i])) digits.Add(text[i]);
                else if (char.IsLetter(text[i])) letters.Add(text[i]);
                else others.Add(text[i]);
            }

            Console.WriteLine(string.Join(string.Empty, digits));
            Console.WriteLine(string.Join(string.Empty, letters));
            Console.WriteLine(string.Join(string.Empty, others));
        }
    }
}