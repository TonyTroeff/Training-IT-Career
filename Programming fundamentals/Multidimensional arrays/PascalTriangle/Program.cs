using System;
using System.Security.Cryptography;

namespace PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());

            long[][] triangle = new long[height][];
            triangle[0] = new[] { 1L };

            for (int i = 1; i < height; i++)
            {
                triangle[i] = new long[i + 1];
                triangle[i][0] = 1;
                triangle[i][i] = 1;

                for (int j = 1; j < i; j++)
                    triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
            }

            for (int i = 0; i < height; i++)
                Console.WriteLine(string.Join(" ", triangle[i]));
        }
    }
}