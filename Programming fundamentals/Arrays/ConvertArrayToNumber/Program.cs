using System;
using System.Linq;

namespace ConvertArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (array.Length > 1)
            {
                int[] next = new int[array.Length - 1];
                for (int j = 0; j < array.Length - 1; j++) next[j] = array[j] + array[j + 1];

                array = next;
            }

            Console.WriteLine(array[0]);
        }
    }
}