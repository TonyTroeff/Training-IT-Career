using System;

namespace SumOfLastKNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] result = new int[n];
            result[0] = 1;

            for (int i = 1; i < n; i++)
            {
                for (int j = i - 1; j >= Math.Max(0, i - k); j--) result[i] += result[j];
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}