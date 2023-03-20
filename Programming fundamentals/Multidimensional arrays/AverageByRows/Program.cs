using System;

namespace AverageByRows
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
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < cols; j++)
                {
                    sum += matrix[i, j];
                    Console.Write($"{matrix[i, j], 10}");
                }

                double average = (double) sum / cols;
                Console.WriteLine($"{average, 10:f2}");
            }
        }
    }
}