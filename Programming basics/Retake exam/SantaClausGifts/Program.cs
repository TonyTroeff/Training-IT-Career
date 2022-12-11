using System;

namespace SantaClausGifts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());

            bool shouldStop = false;
            for (int i = m; !shouldStop && i >= n; i--)
            {
                if (i % 6 == 0)
                {
                    if (i == s) shouldStop = true;
                    else Console.WriteLine(i);
                }
            }
        }
    }
}
