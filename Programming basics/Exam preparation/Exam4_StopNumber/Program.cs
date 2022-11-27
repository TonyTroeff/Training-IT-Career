using System;

namespace Exam4_StopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());

            bool reachedStopNumber = false;
            for (int i = m; i >= n && !reachedStopNumber; i--)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    if (i == s) reachedStopNumber = true;
                    else Console.WriteLine(i);
                }
            }
        }
    }
}
