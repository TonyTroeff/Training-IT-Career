using System;

namespace ExcellentOrNot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            if (grade >= 5.5) Console.WriteLine("Excellent!");
            else Console.WriteLine("Not excellent.");
        }
    }
}
