using System;

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

            DateTime start = DateTime.Now;

            long eighthFibNumber = FibonacciIterative(50);
            Console.WriteLine(eighthFibNumber);

            DateTime finish = DateTime.Now;
            TimeSpan diff = finish - start;
            Console.WriteLine($"Elapsed time: {diff.TotalSeconds:f5}");
        }

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
    }
}
