using System;

namespace FibonacciNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int first = 1, second = 1;
            for (int i = 2; i <= n; i++)
            {
                int next = first + second;
                first = second;
                second = next;
            }

            Console.WriteLine(second);
        }
    }
}
