using System;

namespace ThreeEqualNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (a == b && b == c) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
    }
}
