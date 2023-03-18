using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveTheNumber
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            int lastNum = numbers[numbers.Count - 1];
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] == lastNum)
                    numbers.RemoveAt(i);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}