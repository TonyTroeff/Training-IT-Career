using System;
using System.Collections.Generic;
using System.Linq;

namespace ConvertToAnotherNumberSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int systemBase = inputData[0];
            int numberToConvert = inputData[1];

            List<int> remainders = new List<int>();
            while (numberToConvert != 0)
            {
                int r = numberToConvert % systemBase;
                remainders.Add(r);

                numberToConvert /= systemBase;
            }

            remainders.Reverse();
            Console.WriteLine(string.Join(string.Empty, remainders));
        }
    }
}