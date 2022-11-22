using System;

namespace EvenPowerOf2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int powerOf2 = 1;
            for (int i = 0; i <= n; i += 2)
            {
                Console.WriteLine(powerOf2);
                powerOf2 *= 4;
            }
        }
    }
}
