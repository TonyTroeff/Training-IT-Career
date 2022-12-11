using System;

namespace SantaClausTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string assessment = Console.ReadLine();

            double price = 0, discountPercents = 0, finalAlteration = 0;
            if (roomType == "room for one person")
            {
                price = 18;
            }
            else if (roomType == "apartment")
            {
                price = 25;
                if (days < 10) discountPercents = 0.3;
                else if (days <= 15) discountPercents = 0.35;
                else discountPercents = 0.5;
            }
            else if (roomType == "president apartment")
            {
                price = 35;
                if (days < 10) discountPercents = 0.1;
                else if (days <= 15) discountPercents = 0.15;
                else discountPercents = 0.2;
            }

            if (assessment == "positive") finalAlteration = 1.25;
            else if (assessment == "negative") finalAlteration = 0.9;

            double total = (1 - discountPercents) * (days - 1) * price * finalAlteration;
            Console.WriteLine($"{total:f2}");
        }
    }
}
