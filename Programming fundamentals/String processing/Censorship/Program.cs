using System;

namespace Censorship
{
    internal class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            string sanitizedText = text.Replace(word, new string('*', word.Length));
            Console.WriteLine(sanitizedText);
        }
    }
}