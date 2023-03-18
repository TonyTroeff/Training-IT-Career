using System;

namespace ConvertToDecimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split();

            int systemBase = int.Parse(inputData[0]);
            string numberToConvert = inputData[1];

            int result = 0;
            for (int i = 0; i < numberToConvert.Length; i++)
            {
                int digit = numberToConvert[i] - '0';
                result += digit * (int) Math.Pow(systemBase, numberToConvert.Length - (i + 1));
            }

            Console.WriteLine(result);
        }
    }
}