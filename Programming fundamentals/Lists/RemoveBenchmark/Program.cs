using System;
using System.Collections.Generic;

namespace RemoveBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 10000000; i++) numbers.Add(5);

            DateTime start = DateTime.Now;

            // Took 141.46874 seconds. Complexitiy - quadratic
            // bool canRemove = numbers.Remove(5);
            // while (canRemove) canRemove = numbers.Remove(5);

            // Took 0.01243 seconds. Complexity - quadratic
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] == 5) numbers.RemoveAt(i);
            }

            DateTime finish = DateTime.Now;
            double seconds = (finish - start).TotalSeconds;
            Console.WriteLine($"Took {seconds:f5} seconds");
        }
    }
}