using System;

namespace ChristmasPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int paperRollsCount = int.Parse(Console.ReadLine());
            int fabricRollsCount = int.Parse(Console.ReadLine());
            double glueLiters = double.Parse(Console.ReadLine());
            double discountPercents = double.Parse(Console.ReadLine());

            double total = paperRollsCount * 5.8 + fabricRollsCount * 7.2 + glueLiters * 1.2;
            double totalWithDiscount = total * (1 - (0.01 * discountPercents));
            Console.WriteLine($"{totalWithDiscount:f3}");
        }
    }
}
