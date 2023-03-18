using System;
using System.Linq;

namespace SortNumbers
{
    internal class Program
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Array.Sort(numbers);
            Console.WriteLine(string.Join(" <= ", numbers));
        }
    }
}