using System;

namespace UsdToBgn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dollars = double.Parse(Console.ReadLine());

            double levs = dollars * 1.79549;
            Console.WriteLine($"{levs:f2} BGN");
        }
    }
}
