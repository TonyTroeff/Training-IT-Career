using System;
using System.Linq;

namespace ArrayStatistics
{
    public class Program
    {
        public static void Main()
        {
             int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

             int min = int.MaxValue, max = int.MinValue, sum = 0;
             for (int i = 0; i < numbers.Length; i++)
             {
                 sum += numbers[i];
                 if (numbers[i] < min) min = numbers[i];
                 if (numbers[i] > max) max = numbers[i];
             }

             Console.WriteLine($"Min = {min}");
             Console.WriteLine($"Max = {max}");
             Console.WriteLine($"Sum = {sum}");
             Console.WriteLine($"Average = {(double) sum / numbers.Length}");
        }
    }
}