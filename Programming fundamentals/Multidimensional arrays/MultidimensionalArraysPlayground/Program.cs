using System;

namespace MultidimensionalArraysPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[6, 4];
            Console.WriteLine($"Length of the first dimension: {matrix.GetLength(0)}"); // 6
            Console.WriteLine($"Length of the second dimension: {matrix.GetLength(1)}"); // 4
            Console.WriteLine($"Length: {matrix.Length}"); // 24
            Console.WriteLine($"Rank: {matrix.Rank}"); // 2

            /*// This will throw an exception.
            Console.WriteLine($"Length of the third dimension: {matrix.GetLength(2)}");*/

            matrix[0, 0] = 5;
            matrix[0, 3] = 14;
            matrix[1, 1] = 7;
            matrix[1, 2] = 8;
            matrix[2, 1] = 13;
            matrix[4, 2] = 6;

            // This will not work:
            //Console.WriteLine(string.Join(", ", matrix));

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j]} ");

                Console.WriteLine();
            }
        }
    }
}