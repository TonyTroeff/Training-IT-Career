using System;

namespace SmallShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;
            if (town == "Sofia")
            {
                if (product == "coffee") price = 0.5;
                else if (product == "water") price = 0.8;
                else if (product == "beer") price = 1.2;
                else if (product == "sweets") price = 1.45;
                else if (product == "peanuts") price = 1.6;
            }
            else if (town == "Plovdiv")
            {
                if (product == "coffee") price = 0.4;
                else if (product == "water") price = 0.7;
                else if (product == "beer") price = 1.15;
                else if (product == "sweets") price = 1.3;
                else if (product == "peanuts") price = 1.5;
            }
            else if (town == "Varna")
            {
                if (product == "coffee") price = 0.45;
                else if (product == "water") price = 0.7;
                else if (product == "beer") price = 1.1;
                else if (product == "sweets") price = 1.35;
                else if (product == "peanuts") price = 1.55;
            }

            double total = price * quantity;
            Console.WriteLine(total);
        }
    }
}
