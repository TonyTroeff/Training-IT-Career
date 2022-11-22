using System;

namespace OrderOf2kPlus1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i = i * 2 + 1) Console.WriteLine(i);
        }
    }
}
