using System;
using System.Collections.Generic;

namespace Iterators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Min(5, 13, 25, 14, 16, 17, 17, 12);

            // 100 000 * 4B = 400 000B = 400KB
            
            // This will allocate memory for every item:
            // int[] array = new int[100_000];

            // This will not allocate any additional memory:
            IEnumerable<int> range = Range(1, 100_000);

            Console.WriteLine();
            foreach (int i in range)
            {
                if (i > 10) break;
                Console.WriteLine(i);
            }

            IEnumerable<ulong> fibonacciIterator = Fibonacci(100);
            foreach (ulong fibNum in fibonacciIterator)
            {
                Console.WriteLine(fibNum);
            }
        }

        static int Min(params int[] arguments)
        {
            int min = int.MaxValue;
            for (int i = 0; i < arguments.Length; i++)
            {
                min = Math.Min(min, arguments[i]);
            }

            return min;
        }

        static IEnumerable<ulong> Fibonacci(int count)
        {
            yield return 1;

            ulong a = 0, b = 1;
            for (int i = 1; i <= count; i++)
            {
                ulong c = a + b;

                yield return c;
                a = b;
                b = c;
            }
        }

        static IEnumerable<int> Range(int start, int count)
        {
            int result = start;
            for (int i = 0; i < count; i++)
            {
                // For this iteration, the "iterated" element is start + i.
                yield return result++;
            }
        }

        static T[] Where<T>(T[] items, Func<T, bool> condition)
        {
            List<T> result = new List<T>(capacity: items.Length);

            for (int i = 0; i < items.Length; i++)
            {
                if (condition(items[i]))
                    result.Add(items[i]);
            }

            return result.ToArray();
        }

        static IEnumerable<T> Where<T>(IEnumerable<T> items, Func<T, bool> condition)
        {
            foreach (var item in items)
            {
                if (condition(item))
                    yield return item;
            }
        }
    }
}