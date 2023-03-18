using System;
using System.Collections.Generic;

namespace MinersTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> quantityByMaterial = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                // 1. If not seen, set default
                if (!quantityByMaterial.ContainsKey(input)) quantityByMaterial[input] = 0;

                // 2. Change
                quantityByMaterial[input] += quantity;

                input = Console.ReadLine();
            }

            foreach (var (material, quantity) in quantityByMaterial)
                Console.WriteLine($"{material} -> {quantity}");
        }
    }
}