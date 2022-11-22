using System;

namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long factorial = 1;
            for (int i = 2; i <= n; i++) factorial *= i;

            Console.WriteLine(factorial);
        }
    }
}
