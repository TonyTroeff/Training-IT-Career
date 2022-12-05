using System;

namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pattyPrice = double.Parse(Console.ReadLine());
            double softiePrice = 1.2 * pattyPrice;
            double bunPrice = 0.6 * softiePrice;
            double pretzelPrice = 1.2 + bunPrice;

            int pattiesCount = int.Parse(Console.ReadLine());
            int softiesCount = int.Parse(Console.ReadLine());
            int bunsCount = int.Parse(Console.ReadLine());
            int pretzelsCount = int.Parse(Console.ReadLine());

            double budget = double.Parse(Console.ReadLine());
            double total = pattyPrice * pattiesCount + softiePrice * softiesCount + bunPrice * bunsCount + pretzelPrice * pretzelsCount;

            if (budget < total) Console.WriteLine($"No! {budget - total:f2} leva needed.");
            else Console.WriteLine($"Yes! {total - budget:f2} leva left.");
        }
    }
}
