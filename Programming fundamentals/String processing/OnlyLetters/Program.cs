using System;
using System.Text;

namespace OnlyLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder(capacity: text.Length);
            char previousLetter = default;
            bool hasAnyLetters = false;
            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (char.IsLetter(text[i]) || !hasAnyLetters)
                    sb.Append(text[i]);
                else if (char.IsLetter(previousLetter))
                    sb.Append(previousLetter);

                hasAnyLetters = hasAnyLetters || char.IsLetter(text[i]);
                previousLetter = text[i];
            }

            for (int i = 0; i < sb.Length / 2; i++)
            {
                char temp = sb[i];
                sb[i] = sb[sb.Length - (i + 1)];
                sb[sb.Length - (i + 1)] = temp;
            }

            Console.WriteLine(sb.ToString());
        }
    }
}