using System;

namespace PhoenixGrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            while (message != "ReadMe")
            {
                // If message is valid and palindrome, print "Yes".
                // Else, write "No".
                if (IsValid(message) && IsPalindrome(message)) Console.WriteLine("Yes");
                else Console.WriteLine("No");

                message = Console.ReadLine();
            }
        }

        static bool IsValid(string message)
        {
            string[] phrases = message.Split('.');

            // return phrases.All(x => x.Length == 3 && !x.Contains(' ') && !x.Contains('_'));
            for (int i = 0; i < phrases.Length; i++)
            {
                if (phrases[i].Length != 3 || phrases[i].Contains(' ') || phrases[i].Contains('_'))
                    return false;
            }

            return true;
        }

        static bool IsPalindrome(string message)
        {
            for (int i = 0; i < message.Length / 2; i++)
            {
                if (message[i] != message[message.Length - (i + 1)])
                    return false;
            }

            return true;
        }
    }
}