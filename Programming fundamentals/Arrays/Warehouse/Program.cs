using System;
using System.Linq;

namespace Warehouse
{
    public class Program
    {
        public static void Main()
        {
            string[] products = Console.ReadLine().Split();
            long[] quantities = Console.ReadLine().Split().Select(long.Parse).ToArray();
            decimal[] prices = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

            string command = Console.ReadLine();
            while (command != "done")
            {
                int index = Array.IndexOf(products, command);
                if (index >= 0)
                {
                    Console.WriteLine($"{products[index]} costs: {prices[index]}; Available quantity: {quantities[index]}");
                }

                command = Console.ReadLine();
            }
        }
    }
}