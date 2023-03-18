using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfMinMax
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // int min = numbers.Min(), max = numbers.Max();
            int min = int.MaxValue, max = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max) max = numbers[i];
                if (numbers[i] < min) min = numbers[i];
            }

            /*int[] result = numbers.Where(x => x == min || x == max).Order().ToArray();*/

            List<int> result = new List<int>();
            foreach (int num in numbers)
            {
                if (num == min || num == max) result.Add(num);
            }

            result.Sort();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}