using System;

namespace Exam5_HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double apartmentPrice = 0, studioPrice = 0;
            if (month == "May" || month == "October")
            {
                studioPrice = 50 * nights;
                apartmentPrice = 65 * nights;

                if (nights > 14) studioPrice *= 0.70;
                else if (nights > 7) studioPrice *= 0.95;
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 75.2 * nights;
                apartmentPrice = 68.7 * nights;

                if (nights > 14) studioPrice *= 0.8;
            }
            else if (month == "July" || month == "August")
            {
                studioPrice = 76 * nights;
                apartmentPrice = 77 * nights;
            }

            if (nights > 14) apartmentPrice *= 0.9;

            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
