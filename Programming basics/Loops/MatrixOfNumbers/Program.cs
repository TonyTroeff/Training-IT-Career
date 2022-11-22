using System;

namespace MatrixOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int positionValue = i + j + 1;
                    if (positionValue > n) positionValue = n - (positionValue - n);

                    Console.Write($"{positionValue} ");
                }

                Console.WriteLine();
            }
        }
    }
}
