using System;
using System.Linq;

namespace MaxSubMatrix
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
                int[] numbersFromCurrentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++) matrix[i, j] = numbersFromCurrentRow[j];
            }

            int maxSum = int.MinValue, maxSumRow = -1, maxSumCol = -1;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSumRow = i;
                        maxSumCol = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxSumRow, maxSumCol]} {matrix[maxSumRow, maxSumCol + 1]}");
            Console.WriteLine($"{matrix[maxSumRow + 1, maxSumCol]} {matrix[maxSumRow + 1, maxSumCol + 1]}");
        }
    }
}