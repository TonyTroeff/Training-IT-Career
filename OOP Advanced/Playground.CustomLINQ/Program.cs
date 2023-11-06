using Playground.CustomLINQ.Extensions;
using System;

namespace Playground.CustomLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
                numbers[i] = int.Parse(Console.ReadLine());

            Console.WriteLine($"Even numbers: {string.Join(", ", numbers.Where(x => x % 2 == 0))}");
            Console.WriteLine($"Square roots: {string.Join(", ", numbers.Select(x => Math.Sqrt(x)))}");
            Console.WriteLine($"Min element: {numbers.Min()}");
            Console.WriteLine($"Max element: {numbers.Max()}");

            // Implement the following methods (without using LINQ!):
            // - Where
            // - Select
            // - Min/Max *

            // Use generic (extension) iterator methods
            // Use functions
        }
    }
}