using System;
using System.Collections.Generic;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> quantityByProductName = new Dictionary<string, int>();
            Dictionary<string, double> priceByProductName = new Dictionary<string, double>();

            string input = Console.ReadLine();
            while (input != "stocked")
            {
                string[] data = input.Split();
                string productName = data[0];
                double price = double.Parse(data[1]);
                int quantity = int.Parse(data[2]);

                priceByProductName[productName] = price;

                if (!quantityByProductName.ContainsKey(productName))
                    quantityByProductName[productName] = 0;
                quantityByProductName[productName] += quantity;

                input = Console.ReadLine();
            }

            double grandTotal = 0;
            foreach (var (productName, quantity) in quantityByProductName)
            {
                double price = priceByProductName[productName];
                double totalPrice = quantity * price;

                Console.WriteLine($"{productName}: ${price:f2} * {quantity} = ${totalPrice:f2}");

                grandTotal += totalPrice;
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${grandTotal:f2}");
        }
    }
}