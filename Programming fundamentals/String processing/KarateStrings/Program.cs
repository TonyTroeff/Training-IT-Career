using System;
using System.Reflection;
using System.Text;

namespace KarateStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            StringBuilder sb = new StringBuilder(capacity: inputLine.Length);

            int elementsToRemove = 0;
            for (int i = 0; i < inputLine.Length; i++)
            {
                if (inputLine[i] == '>' && i + 1 < inputLine.Length && char.IsDigit(inputLine[i + 1]))
                {
                    elementsToRemove += inputLine[i + 1] - '0';
                }
                else if (elementsToRemove > 0)
                {
                    elementsToRemove--;
                    continue;
                }

                sb.Append(inputLine[i]);
            }

            Console.WriteLine(sb.ToString());
        }

        /*static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            StringBuilder sb = new StringBuilder(inputLine);

            int elementsToRemove = 0, index  = 0;
            while (index < sb.Length)
            {
                if (sb[index] == '>' && index + 1 < sb.Length && char.IsDigit(sb[index + 1]))
                {
                    elementsToRemove += sb[index + 1] - '0';
                }
                else if (elementsToRemove > 0)
                {
                    elementsToRemove--;
                    sb.Remove(index, 1);

                    // index--;
                    continue;
                }

                index++;
            }

            Console.WriteLine(sb.ToString());
        }*/
    }
}