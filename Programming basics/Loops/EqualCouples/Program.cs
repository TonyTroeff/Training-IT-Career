using System;

namespace EqualCouples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int maxDiff = 0, lastSum = 0;
            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int sum = a + b;

                if (i > 0)
                {
                    int currentDiff = Math.Abs(sum - lastSum);
                    if (currentDiff > maxDiff) maxDiff = currentDiff;
                }

                lastSum = sum;
            }

            if (maxDiff == 0) Console.WriteLine($"Yes, value={lastSum}");
            else Console.WriteLine($"No, maxdiff={maxDiff}");
        }
    }
}
