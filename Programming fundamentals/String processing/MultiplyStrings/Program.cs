using System;

namespace MultiplyStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split();

            string first = inputData[0], second = inputData[1];

            long result = 0;
            int maxLength = Math.Max(first.Length, second.Length);
            for (int i = 0; i < maxLength; i++)
            {
                int a = 1, b = 1;
                if (i < first.Length) a = first[i];
                if (i < second.Length) b = second[i];

                result += a * b;

                /*if (i < first.Length && i < second.Length)
                    result += first[i] * second[i];
                else if (i < first.Length) result += first[i];
                else result += second[i];*/
            }

            Console.WriteLine(result);
        }
    }
}