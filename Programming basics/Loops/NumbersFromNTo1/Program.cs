using System;

namespace NumbersFromNTo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = n; i >= 1; i--) Console.WriteLine(i);
        }
    }
}
