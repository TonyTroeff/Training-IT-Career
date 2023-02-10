using System;

namespace SumOfCharacters
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                char currentSymbol = char.Parse(Console.ReadLine());
                sum += currentSymbol;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}