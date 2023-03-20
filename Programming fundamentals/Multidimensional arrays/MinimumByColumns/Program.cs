using System;
using System.Linq;

namespace MinimumByColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] currentRowNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = currentRowNumbers[j];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write($"{matrix[i, j],5}");
                Console.WriteLine();
            }

            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                int min = int.MaxValue;
                for (int rowIndex = 0; rowIndex < rows; rowIndex++)
                {
                    if (matrix[rowIndex, colIndex] < min)
                        min = matrix[rowIndex, colIndex];
                }

                Console.Write($"{min,5}");
            }
        }
    }
}