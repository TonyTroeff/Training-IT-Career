using System;

namespace Exam4_Money
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int btc = int.Parse(Console.ReadLine());
            double cny = double.Parse(Console.ReadLine());
            double commision = double.Parse(Console.ReadLine());

            double totalInLevs = btc * 1168 + cny * 0.15 * 1.76;
            double total = (totalInLevs / 1.95) * (1 - commision * 0.01);
            Console.WriteLine(total);
        }
    }
}
