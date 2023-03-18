using System;
using System.Linq;

namespace FoldAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int k = numbers.Length / 4;
            int[] top = new int[k * 2];
            int[] bottom = new int[k * 2];

            for (int i = 0; i < k; i++)
                top[i] = numbers[k - (i + 1)];
            for (int i = 0; i < k; i++)
                top[k + i] = numbers[numbers.Length - (i + 1)];

            for (int i = 0; i < 2 * k; i++)
                bottom[i] = numbers[k + i];

            int[] sum = new int[k * 2];
            for (int i = 0; i < k * 2; i++) sum[i] = top[i] + bottom[i];

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}