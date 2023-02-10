using System;
using System.Text;

namespace StringConcatenation
{
    public class Program
    {
        public static void Main()
        {
            char separator = char.Parse(Console.ReadLine());
            string evenOrOdd = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            bool concatenateOnEvenSteps = evenOrOdd == "even";
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                bool isEvenStep = (i % 2 == 0);
                if (concatenateOnEvenSteps == isEvenStep)
                {
                    sb.Append(input);
                    sb.Append(separator);
                }
            }

            if (sb.Length > 0) sb.Length--;
            Console.WriteLine(sb);
        }
    }
}