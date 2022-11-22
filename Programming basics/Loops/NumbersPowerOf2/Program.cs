using System;

namespace NumbersPowerOf2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int powerOf2 = 1; // We start with 2^0 = 1 and gradually multiply with 2
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine(powerOf2);
                powerOf2 *= 2;
            }
        }
    }
}
