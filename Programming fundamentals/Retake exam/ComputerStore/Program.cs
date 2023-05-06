using System;

namespace ComputerStore
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            decimal price = 0;

            while (input != "regular" && input != "special")
            {
                decimal current = decimal.Parse(input);
                if (current < 0) Console.WriteLine("Invalid price!");
                else price += current;

                input = Console.ReadLine();
            }

            if (price == 0) Console.WriteLine("Invalid order!");
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {price:f2}$");

                decimal taxes = price * 0.2m;
                Console.WriteLine($"Taxes: {taxes:f2}$");

                decimal finalPrice = price + taxes;
                if (input == "special") finalPrice *= 0.9m;

                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {finalPrice:f2}$");
            }
        }
    }
}