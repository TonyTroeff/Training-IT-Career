using System;
using System.Collections.Generic;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> prices = new Dictionary<string, decimal>();
            Dictionary<string, int> quantities = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "buy")
            {
                string[] data = input.Split();
                string productName = data[0];

                prices[productName] = decimal.Parse(data[1]);
                if (!quantities.ContainsKey(productName)) quantities[productName] = 0;
                quantities[productName] += int.Parse(data[2]);

                input = Console.ReadLine();
            }

            foreach (string productName in prices.Keys)
                Console.WriteLine($"{productName} -> {prices[productName] * quantities[productName]:f2}");
        }
    }
}