using System;

namespace Conference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());
            int caterring = rent * 2;
            double drinks = 0.85 * caterring;
            double gifts = (caterring + drinks) / 7;

            double total = rent + caterring + drinks + gifts;
            Console.WriteLine($"{total:f2}");
        }
    }
}
