using System;
using System.Linq;

namespace InputOutputJaggedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            /* Approach 1:
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];

                int[] numbersFromCurrentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                    matrix[i][j] = numbersFromCurrentRow[j];
            }*/

            for (int i = 0; i < rows; i++)
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < rows; i++)
                Console.WriteLine(string.Join(", ", matrix[i]));

            Console.WriteLine($"Length of the first dimension: {matrix.GetLength(0)}");

            // This is not possible for jagged arrays.
            // Console.WriteLine($"Length of the second dimension: {matrix.GetLength(1)}");
            
            Console.WriteLine($"Length: {matrix.Length}");
            Console.WriteLine($"Rank: {matrix.Rank}");
        }
    }
}