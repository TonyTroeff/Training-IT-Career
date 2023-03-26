using System;
using System.Linq;

namespace Raindrops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double density = double.Parse(Console.ReadLine());

            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int raindropsCount = data[0], squareMeters = data[1];

                sum += (double)raindropsCount / squareMeters;
            }

            double result = sum / density;
            Console.WriteLine($"{result:f3}");
        }
    }
}