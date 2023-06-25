using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // fib(0) = 1
            // fib(1) = 1
            // fib(n) = fib(n - 1) + fib(n - 2)
            // (0) 1 1 2 3 5 8 13 21 34 ...

            //int[] array = new int[10_000];
            //for (int i = 0; i < array.Length; i++) array[i] = 1;

            //DateTime start = DateTime.Now;

            // long eighthFibNumber = FibonacciRecursive(50);
            // Console.WriteLine(eighthFibNumber);

            //DateTime finish = DateTime.Now;
            //TimeSpan diff = finish - start;
            //Console.WriteLine($"Elapsed time: {diff.TotalSeconds:f5}");

            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int middle = array.Length / 2;

            IEnumerable<int> firstHalf = array.Take(middle).OrderBy(x => x);
            IEnumerable<int> secondHalf = array.Skip(middle).OrderByDescending(x => x);
            int[] result = firstHalf.Concat(secondHalf).ToArray();
        }

        static void AnalyzeRecursionChain(int n)
        {
            if (n == 0) return;

            Console.WriteLine($"Pre-execution step for {n}. {new string('*', n)}");
            AnalyzeRecursionChain(n - 1);
            Console.WriteLine($"Post-execution step for {n}. {new string('#', n)}");
        }

        // 10000 -> 0.01088s
        // More than 10000 - Stack overflow.
        static int SumRecursively(int index, int[] numbers)
        {
            if (index == numbers.Length) return 0;
            return numbers[index] + SumRecursively(index + 1, numbers);
        }

        // 10000 -> 0.01177s
        static int SumIteratively(int[] numbers)
        {
            int result = 0;
            for (int i = 0; i < numbers.Length; i++) result += numbers[i];
            return result;
        }

        static long FactorialRecursively(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * FactorialRecursively(n - 1);
        }

        static void EndlessRecursionLoop() => EndlessRecursionLoop();

        static void Demo(int n) // max(n^2, 1) => O(n^2)
        {
            if (n % 2 == 0) // O(n^2)
            {
                for (int i = 0; i < n; i++) // n iterations, in total n^2
                {
                    for (int j = 0; j < n; j++) // n iterations
                    {
                        Console.WriteLine($"{i}, {j}");
                    }
                }
            }
            else // O(1)
            {
                Console.WriteLine("odd");
            }
        }

        // n = 40 => 1.46240s
        // n = 50 => 167.68371s
        static long FibonacciRecursive(int n)
        {
            if (n == 0 || n == 1) return 1;
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        // n = 40 => 0.00880s
        // n = 50 => 0.00756s
        static long FibonacciIterative(int n)
        {
            long a = 1, b = 1;
            for (int i = 2; i <= n; i++)
            {
                long next = a + b;
                a = b;
                b = next;
            }

            return b;
        }

        static void FindMajorantAndMode()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            Dictionary<int, int> occurrencesByNumber = new Dictionary<int, int>();
            int max = 0, firstMaxElement = 0, maxElementsSum = 0, maxElementsCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (!occurrencesByNumber.ContainsKey(array[i]))
                    occurrencesByNumber[array[i]] = 0;
                int currentOccurrences = ++occurrencesByNumber[array[i]];

                if (currentOccurrences > max)
                {
                    max = currentOccurrences;
                    firstMaxElement = array[i];
                    maxElementsSum = 0;
                    maxElementsCount = 0;
                }

                if (currentOccurrences == max)
                {
                    maxElementsSum += array[i];
                    maxElementsCount++;
                }
            }

            int[] filteredArray = array.Where(x => occurrencesByNumber[x] % 2 == 0).ToArray();
            Console.WriteLine(string.Join(", ", filteredArray));

            if (max >= array.Length / 2 + 1)
                Console.WriteLine($"This array has a majorant: {firstMaxElement}");
            else Console.WriteLine("This array does not have a majorant.");

            Console.WriteLine($"The mode is: {(double)maxElementsSum / maxElementsCount:f3}");
        }
    }
}
