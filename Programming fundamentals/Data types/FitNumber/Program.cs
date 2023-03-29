using System;
using System.Collections.Generic;

namespace FitNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> typesThatFit = new List<string>();
            if (sbyte.TryParse(input, out _)) typesThatFit.Add("sbyte");
            if (byte.TryParse(input, out _)) typesThatFit.Add("byte");
            if (short.TryParse(input, out _)) typesThatFit.Add("short");
            if (ushort.TryParse(input, out _)) typesThatFit.Add("ushort");
            if (int.TryParse(input, out _)) typesThatFit.Add("int");
            if (uint.TryParse(input, out _)) typesThatFit.Add("uint");
            if (long.TryParse(input, out _)) typesThatFit.Add("long");

            if (typesThatFit.Count > 0)
            {
                Console.WriteLine($"{input} can fit in:");
                foreach (var t in typesThatFit)
                    Console.WriteLine($"* {t}");
            }
            else
            {
                Console.WriteLine($"{input} can't fit in any type");
            }
        }
    }
}