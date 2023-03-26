using System;

namespace Resurection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long bodyLength = long.Parse(Console.ReadLine());
                decimal bodyWidth = decimal.Parse(Console.ReadLine());
                long wingLength = long.Parse(Console.ReadLine());

                // totalYears = {totalLength} ^ 2 * ({totalWidth} + 2 * {wingLength})
                decimal reincarnationYears = bodyLength * bodyLength * (bodyWidth + 2 * wingLength);
                Console.WriteLine(reincarnationYears);
            }
        }
    }
}