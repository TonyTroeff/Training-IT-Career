using System;

namespace Exam1_TransportPrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string partOfDay = Console.ReadLine();

            double totalPrice = 0;
            if (kilometers < 20)
            {
                double taxiPrice = 0;
                if (partOfDay == "day") taxiPrice = 0.79;
                else if (partOfDay == "night") taxiPrice = 0.9;

                totalPrice = 0.7 + taxiPrice * kilometers;
            }
            else if (kilometers < 100)
            {
                totalPrice = 0.09 * kilometers;
            }
            else
            {
                totalPrice = 0.06 * kilometers;
            }

            Console.WriteLine(totalPrice);
        }
    }
}
