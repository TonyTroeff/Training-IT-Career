using System;

namespace VowelOrDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());
            if (char.IsDigit(symbol)) Console.WriteLine("digit");
            else if (IsVowel(char.ToLower(symbol))) Console.WriteLine("vowel");
            else Console.WriteLine("other");
        }

        static bool IsVowel(char symbol) => symbol == 'a' || symbol == 'e' || symbol == 'i' || symbol == '0' || symbol == 'u';
    }
}