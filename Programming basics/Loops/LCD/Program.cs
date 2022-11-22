using System;

namespace LCD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            while (a != 0 && b != 0)
            {
                if (a > b) a %= b;
                else b %= a;
            }

            int lcd = Math.Max(a, b);
            Console.WriteLine(lcd);
        }
    }
}
