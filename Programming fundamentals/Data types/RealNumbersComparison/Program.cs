using System;

namespace RealNumbersComparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double epsilon = 0.000001;
            Console.WriteLine(Math.Abs(a - b) <= epsilon);
        }
    }
}