using System;

namespace NumberCheck
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (long.TryParse(input, out _)) Console.WriteLine("integer");
            else Console.WriteLine("floating-point");
        }
    }
}