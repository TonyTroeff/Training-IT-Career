using System;
using System.Collections.Generic;

namespace CapacityBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;

            // Took 7.80374 seconds.
            // List<int> list = new List<int>();
            
            // Took 3.36126 seconds.
            List<int> list = new List<int>(1_000_000_000);
            for (int i = 0; i < 1_000_000_000; i++)
                list.Add(5);

            DateTime finish = DateTime.Now;
            double totalSeconds = (finish - start).TotalSeconds;

            Console.WriteLine($"Took {totalSeconds:f5} seconds.");
        }
    }
}