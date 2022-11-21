using System;

namespace MaxOf2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a > b) Console.WriteLine(a);
            else Console.WriteLine(b);
        }
    }
}
